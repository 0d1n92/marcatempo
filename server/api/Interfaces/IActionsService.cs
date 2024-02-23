using api.DTOs;
using System.Threading.Tasks;
using api.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace api.Interface
{
    public interface IActionsService
    {
        Task<(bool Success, string Message, int Count, IEnumerable<UserActions> Items)> OperatorActionListAsync(int? page, int? pageSize, RequestActionListDto request);
        Task<(bool Success, string Message)> Delete(int id);
        Task<(bool Success, string Message)> Update(int id, RequestActionDto request);
        (bool Success, string Totals) CalcolateTotal(RequestActionTotalDto request);
        (bool Success, MemoryStream stream) ExportCsvFile(List<RequestActionCsvDto> request);
        Task<(bool Success, string Message)> AddAction(int id, RequestAddActionDto request);
        Task<(bool Success, string Message, int Count, IEnumerable<UserActions> Items)> UserActionListAsync(int? page, int? pageSize, RequestActionListDto request, string token);
    }
}
