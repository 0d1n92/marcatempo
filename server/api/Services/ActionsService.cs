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
    public async Task<(bool Success, string Message, int Count, IEnumerable<User> Items)> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request )
    {
        try
        {
            List<DateTime> dates = DateTime.Parse(request.InitDate).Range( DateTime.Parse(request.EndDate)).ToList();
            var operators = _context.Users.Include(src => src.Activities).Include(src => src.QRCode).Where(x => x.Role.Id != (int)EnumRoles.Administrator).AsQueryable();
            var listAction = dates.Select(date => _context.Users.Include(src => src.Activities.Where( act  => act.Entry.ToString() == "2022-08-12 19:48:44.841291"))).ToList();
            //
            var count = operators.Count();
            operators = operators.Paginate(page, pageSize);
            return (true, "Operator info", count, await operators.ToListAsync());

        }
        catch (Exception e)
        {
            return (false, e.Message, 0, new List<User>());

        }
    }
}

