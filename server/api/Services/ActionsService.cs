using api.Helpers;
using api.DTOs;
using System;
using System.Linq;
using api.Interface;
using api.Model.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using api.Utilitis.Enum;
using api.Extensions;
using api.Utilitis;
using System.Linq.Dynamic.Core;

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
                List<UserActions> actUsr= _context.Users.AsEnumerable().Where(x => x.RoleId != (int)EnumRoles.Administrator).GroupJoin(action, user => user.Id, action => action.UserId, (user, action) => new UserActions(date,user.FirstName, user.LastName, action.Where(a => a.Entry.Value.Date == date.Date).ToList(), user.Username)).ToList();

                if (request.UsersName.Any())
                {
                    var filteredByUsrName = new List<UserActions>();
                    foreach(var user in actUsr)
                    {
                        if(request.UsersName.Contains(user.UserName))
                        filteredByUsrName.Add(user);
                    }
                    usersAct.AddRange(filteredByUsrName);

                }
                else {

                  usersAct.AddRange(actUsr);

                }             
            }

            usersAct.ForEach((x) => x.Index = usersAct.IndexOf(x));
            IQueryable <UserActions> response = usersAct.AsQueryable();

            if (request.SortBy.Any())
            {
                string multiOrders =string.Concat(request.SortBy.AsQueryable().Select((ord, index) => $"{ord} {(request.SortDesc[index + 1] ? "DESC," : "ASC,") }").ToArray());
                response = response.OrderBy(multiOrders.Remove(multiOrders.Length -1));
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
 
            Model.Entity.Action action = _context.Actions.Where(act => act.Id == Id ).First(); 
            _context.Actions.Remove(action);
            await _context.SaveChangesAsync();
            return (true, "action deleted");

        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }
}

