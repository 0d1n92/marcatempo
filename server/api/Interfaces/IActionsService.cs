using api.DTOs;
using System.Threading.Tasks;
using api.Helpers;
using System.Collections.Generic;

namespace api.Interface
{
    public interface IActionsService
    {
        Task<(bool Success, string Message, int Count, IEnumerable<UserActions> Items)> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request);
    }
}
