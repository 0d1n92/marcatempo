using api.Helpers;
using api.DTOs;
using System;
using System.Linq;
using api.Interface;
using api.Model.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Services;
public class QrcodesService : IQrcodesService
{
    private DataContext _context;
    public QrcodesService(
          DataContext context
        )
    {
        _context = context;
    }
    public async Task<(bool Success, string Message, Model.Entity.Action data)> Postmark(RequestPostmarkerQRcodeDto request)
    {
        var action = new Model.Entity.Action();
        try
        {
            var qrcode = await _context.QRcodes.Include(qr => qr.User).Where(qr => qr.Token== request.Token).FirstAsync();
         
                if (request.Exit && qrcode != null)
                {
                    var lastUserAction = _context.Actions.Where(a => a.UserId == qrcode.UserId).ToList().OrderBy(x => x.Id).Last(); 

                    if ((bool)lastUserAction.IsPresent && lastUserAction.Exit == null)
                    {
                        lastUserAction.Exit = DateTime.Now;

                       var updateAct =  _context.Actions.Update(lastUserAction);
                       await _context.SaveChangesAsync();

                    return (true, "Exit", updateAct.Entity);
                    }
                    
                    return (false, "Entry date doesn't exist or the entry is already present ", action);
                }
                
                action.IsPresent = true;
                action.Entry = DateTime.Now;
                action.UserId= qrcode.UserId;
                _context.Actions.Add(action);
               
                await _context.SaveChangesAsync();
                return (true, "Entry", action);
   
        }
        catch (Exception ex)
        {
            return (false, ex.Message, new Model.Entity.Action());
        }
    }
    public async Task<(bool Success, string Message, QRcode data)> UpdateQrcode(Guid token)
    {
        try
        {
            var qrcode =  await _context.QRcodes.SingleOrDefaultAsync(qr => qr.Token == token);
            qrcode.Token = Guid.NewGuid();
            _context.QRcodes.Update(qrcode);
            await _context.SaveChangesAsync();
            return (true, "Qrcode Update", qrcode);
        }
        catch (Exception ex)
        {
            return (false, ex.Message, new QRcode());

        }
    }
}

