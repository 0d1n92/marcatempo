using api.Helpers;
using api.DTOs;
using System;
using System.Linq;
using api.Interface;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using api.Utilitis.Enum;
using api.Extensions;
using api.Utilitis;
using System.Linq.Dynamic.Core;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace api.Services;
public class ActionsService : IActionsService
{
    private DataContext _context;
    public ActionsService(
          DataContext context
        )
    {
        _context = context;
    }
    public async Task<(bool Success, string Message, int Count, IEnumerable<UserActions> Items)> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request)
    {
        try
        {
            List<DateTime> dates = DateTime.Parse(request.InitDate).Range(DateTime.Parse(request.EndDate)).ToList();
            var action = await _context.Actions.AsNoTracking().ToListAsync();
          

            var usersAct = new List<UserActions>();

            foreach (var date in dates)
            {
                List<UserActions> actUsr = _context.Users.AsEnumerable().Where(x => x.RoleId != (int)EnumRoles.Administrator).GroupJoin(action,user => user.Id, action => action.UserId, (user, action) => new UserActions(date, user.FirstName, user.LastName, action.Where(a => a.Entry.Value.Date == date.Date).ToList(), user.Username)).ToList();
               
                if (request.Present == EnumUserPresent.Present)
                {
                    actUsr = actUsr.Where(x => x.Actions.Count > 0).ToList();
                } else if (request.Present == EnumUserPresent.Absent)
                {
                    actUsr = actUsr.Where(x => x.Actions.Count == 0).ToList();
                }

                if (request.UsersName.Any())
                {
                    var filteredByUsrName = new List<UserActions>();
                    foreach (var user in actUsr)
                    {
                        if (request.UsersName.Contains(user.UserName))
                            filteredByUsrName.Add(user);
                    }
                    usersAct.AddRange(filteredByUsrName);

                }
                else
                {

                    usersAct.AddRange(actUsr);

                }
            }

            usersAct.ForEach((x) => x.Index = usersAct.IndexOf(x));
            IQueryable<UserActions> response = usersAct.AsQueryable();

            if (request.SortBy.Any())
            {
                string multiOrders = string.Concat(request.SortBy.AsQueryable().Select((ord, index) => $"{ord} {(request.SortDesc[index] ? "DESC," : "ASC,") }").ToArray());
                response = response.OrderBy(multiOrders.Remove(multiOrders.Length - 1));
            }

            int count = response.Count();
            response = response.Paginate(page, pageSize);
            return (true, "Operator info", count, response);

        }
        catch (Exception e)
        {
            return (false, e.Message, 0, new List<UserActions>());

        }

    }
    public async Task<(bool Success, string Message)> Delete(int Id)
    {
        try
        {

            Model.Entity.Action action = _context.Actions.Where(act => act.Id == Id).First();
            _context.Actions.Remove(action);
            await _context.SaveChangesAsync();
            return (true, "action deleted");

        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }

    public async Task<(bool Success, string Message)> Update(int id, RequestActionDto request)
    {
        try
        {
            Model.Entity.Action action = await _context.Actions.FindAsync(id);
            DateTime entry = DateTime.Parse(request.Entry);
            DateTime exit = DateTime.Parse(request.Exit);
            if (entry > exit)
            {
                return (false, "The entry date must be less than the exit date");
            }
            action.Entry = entry;
            action.Exit = exit;
            await _context.SaveChangesAsync();
            return (true, "action update");
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }

    }

    public (bool Success, string Totals) CalcolateTotal(RequestActionTotalDto request)
    {
        try
        {
            var totals = new TimeSpan();
            request.TotalsUsers.ForEach(x =>
            {
                var value = String.Format("{0:0.00}", x);
                int hours = (int)x;
                if (hours >= 24)
                {
                    value = new TimeSpan(hours,    // hours
                       int.Parse(value.Split(',')[1]),    // minutes
                       00   // seconds
                       ).ToString();
                }
                else
                {
                    value = value.Replace(',', ':') + ":00";
                }

                totals += TimeSpan.Parse(value);
            }
            );

            return (true, $"{(int)totals.TotalHours},{totals.Minutes.ToString("00")}");
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }

    public (bool Success, MemoryStream stream) ExportCsvFile(List<RequestActionCsvDto> request)
    {
        try { 

             var memoryStream = new MemoryStream();
             var streamWriter = new StreamWriter(memoryStream, leaveOpen: true);
             var config = new CsvConfiguration(CultureInfo.InvariantCulture)
             {
                 Delimiter = ";",
             };
             var csvWriter = new CsvWriter(streamWriter, config);
             var Dateheaders = new List<string>();
             var UserNames = new List<string>();

             request.ForEach(x =>
             {

                 if (!Dateheaders.Contains(x.Date))
                 {
                     Dateheaders.Add(x.Date);
                 } 
                 if (!UserNames.Contains(x.UserName))
                 {
                     UserNames.Add(x.UserName);
                 }

             });

             var headers = new List<string>()
             {
                 "Nome",
                 "Cognome",
             };
             headers.AddRange(Dateheaders);
             headers.Add("Totali");
             foreach (var header in headers)
             {
                 csvWriter.WriteField(header);
             }
             csvWriter.NextRecord();

    
            foreach (var name in UserNames)
            {
                var listTotal = new RequestActionTotalDto();
                var usr = request.First(x => x.UserName == name);
                csvWriter.WriteField(usr.FirstName);
                csvWriter.WriteField(usr.LastName);
                listTotal.TotalsUsers = new List<decimal>();
                request.Where(x => x.UserName == name).ToList().ForEach(x =>
                {
                    listTotal.TotalsUsers.Add(x.Total);
                    csvWriter.WriteField(String.Format("{0:0.00}", x.Total));
                }
                );
                csvWriter.WriteField(String.Format("{0:0.00}", this.CalcolateTotal(listTotal).Totals));
                csvWriter.NextRecord();
            }

            csvWriter.Flush();
            memoryStream.Position = 0;
            return (true, memoryStream);
        }
        catch (Exception e)
        {
            return (false, new MemoryStream());
        }

    }
}
