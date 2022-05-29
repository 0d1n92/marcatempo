using api.Helpers;
using api.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using api.Interface;
using api.Model.Entity;

namespace api.Services
{
    public class QrcodesService : IQrcodesService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        public QrcodesService(
              DataContext context,
              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PostmarkerQRcodeResponse Postmarker(PostmarkerQRcodeRequest model)
        {
            var qrcode = _context.QRcodes.SingleOrDefault(x => x.UserId == model.UserId && x.token == model.QRtoken);
            var user = _context.Users.SingleOrDefault(x => x.Id == model.UserId);

            var activity = _mapper.Map<Activity>(new Activity());

            if (qrcode == null || user == null)
            {
                throw new AppException("QRcode or user not found ");
            }

            if (model.Exit)
            {
                var findedActivity = GetActivity(model.UserId);

                if ((bool)findedActivity.IsPresent && findedActivity.Exit == null)
                {
                    findedActivity.Exit = DateTime.Now;

                    activity = _mapper.Map(findedActivity, activity);
                    _context.Activities.Update(activity);
                }
                else
                {
                    throw new KeyNotFoundException("Entry date doesn't exist or the entry is already present ");
                }
            }
            else
            {
                activity.UserId = model.UserId;
                activity.IsPresent = true;
                activity.Entry = DateTime.Now;
                _context.Activities.Add(activity);
            }
            _context.SaveChanges();
            var response = _mapper.Map<PostmarkerQRcodeResponse>(activity);
            return response;
        }
        private Activity GetActivity(int id)
        {
            var activity = _context.Activities.Where(a => a.UserId == id).ToList().OrderBy(x => x.Id == id).Last();
            //var activity = _context.Activities.Where(a => a.UserId == id).OrderBy(x => x.Id == id).LastOrDefault();
            if (activity == null) throw new KeyNotFoundException("Activity not found");
            return activity;
        }

    }
}
