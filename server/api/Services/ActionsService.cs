﻿using api.Helpers;
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
    public async Task<(bool Success, string Message, int Count, IEnumerable<UserActions> Items)> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request)
    {
        try
        {
            List<DateTime> dates = DateTime.Parse(request.InitDate).Range(DateTime.Parse(request.EndDate)).ToList();
            var action = await _context.Actions.AsNoTracking().ToListAsync();
            var usersAct = new List<UserActions>();

            foreach (var date in dates)
            {
                var actUsr= _context.Users.AsEnumerable().Where(x => x.RoleId != (int)EnumRoles.Administrator).GroupJoin(action, user => user.Id, action => action.UserId, (user, action) => new UserActions(date,user.FirstName, user.LastName, action.Where(a => a.Entry.Value.Date == date.Date).ToList())).ToList();
                usersAct.AddRange(actUsr);
            }

            var response = usersAct.AsQueryable();
            var count = response.Count();
            response = response.Paginate(page, pageSize);
            return (true, "Operator info", count, response);

        }
        catch (Exception e)
        {
            return (false, e.Message, 0, new List<UserActions>());

        }

    }
}
