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
        private readonly IMapper _mapper;
        private IJwtUtils _jwtUtils;
        public QrcodesService(
              DataContext context,
              IMapper mapper,
              IJwtUtils jwtUtils
            )
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }
        public PostmarkerQRcodeResponseDto Postmark(PostmarkerQRcodeRequestDto model)
        {
            var qrcode = _context.QRcodes.SingleOrDefault(x => x.UserId == model.UserId && x.token == model.QRtoken);
            var user = _context.Users.SingleOrDefault(x => x.Id == model.UserId);

            var action = _mapper.Map<Model.Entity.Action>(new Model.Entity.Action());

            if (qrcode == null || user == null)
            {
                throw new AppException("QRcode or user not found ");
            }

            if (model.Exit)
            {
                var findedAction = GetAction(model.UserId);

                if ((bool)findedAction.IsPresent && findedAction.Exit == null)
                {
                    findedAction.Exit = DateTime.Now;

                    action = _mapper.Map(findedAction, action);
                    _context.Actions.Update(action);
                }
                else
                {
                    throw new KeyNotFoundException("Entry date doesn't exist or the entry is already present ");
                }
            }
            else
            {
                action.UserId = model.UserId;
                action.IsPresent = true;
                action.Entry = DateTime.Now;
                _context.Actions.Add(action);
            }
            _context.SaveChanges();
            var response = _mapper.Map<PostmarkerQRcodeResponseDto>(action);
            return response;
        }
        private Model.Entity.Action GetAction(int id)
        {
            var action = _context.Actions.Where(a => a.UserId == id).ToList().OrderBy(x => x.Id == id).Last();
            //var activity = _context.Activities.Where(a => a.UserId == id).OrderBy(x => x.Id == id).LastOrDefault();
            if (action == null) throw new KeyNotFoundException("Activity not found");
            return action;
        }

        public async Task<(bool Success, string Message, QRcode? qrcode)> UpdateQrcode(int id)
        {
            try
            {
                QRcode qrcode = (QRcode)_context.QRcodes.Where(x => x.UserId == id);
                qrcode.token = _jwtUtils.QRGenerateToken(qrcode);
                _context.QRcodes.Update(qrcode);
                await _context.SaveChangesAsync();
                return (true, "Qrcode Update", qrcode);
            } catch (Exception ex)
            {
                return (false, ex.Message, new QRcode());

            }
        }  
    }

