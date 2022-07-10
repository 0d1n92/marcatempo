using api.Helpers;
using api.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using api.Interface;
using api.Model.Entity;
using System.Threading.Tasks;

namespace api.Services;
public class QrcodesService : IQrcodesService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    public QrcodesService(
          DataContext context,
          IJwtUtils jwtUtils
        )
    {
        _context = context;
        _jwtUtils = jwtUtils;
    }
    public async Task<(bool Sucess, string Message, Model.Entity.Action data)> Postmark(PostmarkerQRcodeRequestDto model)
    {
        var action = new Model.Entity.Action();
        try
        {
            var qrcode = _context.QRcodes.SingleOrDefault(x => x.UserId == model.UserId && x.token == model.QRtoken);
            var user = _context.Users.SingleOrDefault(x => x.Id == model.UserId);
            if (qrcode != null && user != null)
            {

                if (model.Exit)
                {
                    var findedAction = GetAction(model.UserId);

                    if ((bool)findedAction.IsPresent && findedAction.Exit == null)
                    {
                        findedAction.Exit = DateTime.Now;

                        _context.Actions.Update(findedAction);
                    }
                    else
                    {
                        return (false, "Entry date doesn't exist or the entry is already present ", action);

                    }
                }
                else
                {
                    action.UserId = model.UserId;
                    action.IsPresent = true;
                    action.Entry = DateTime.Now;
                    _context.Actions.Add(action);
                }

                await _context.SaveChangesAsync();
                return (true, "Marked", action);
            } else
            {
                return (false, "User or Qrcode not exist", new Model.Entity.Action());
            }
        }
        catch (Exception ex)
        {
            return (false, ex.Message, new Model.Entity.Action());
        }
    }

    private Model.Entity.Action GetAction(int id)
    {
        var action = _context.Actions.Where(a => a.UserId == id).ToList().OrderBy(x => x.Id == id).Last();
    
        if (action == null) throw new KeyNotFoundException("Activity not found");
        return action;
    }

    public async Task<(bool Success, string Message, QRcode? data)> UpdateQrcode(int id)
    {
        try
        {
            QRcode qrcode = (QRcode)_context.QRcodes.Where(x => x.UserId == id);
            qrcode.token = _jwtUtils.QRGenerateToken(qrcode);
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

