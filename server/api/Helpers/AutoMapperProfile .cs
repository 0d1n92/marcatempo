using AutoMapper;
using api.DTOs;
using api.Model.Entity;
using System.Linq;
using api.Utilitis.Enum;
using System;

namespace api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EnumRoles, Role>().ConstructUsing((src, dest) => new Role { Id = (int)src }); 
            CreateMap<User, RequestCreateUserDto>()
               .ForMember(cr => cr.Role, opt => opt.MapFrom(usr => usr.Role.Name))
               .ForMember(cr => cr.Avatar, opt => opt.MapFrom(opt => opt.UserMetas.Select(x => x.Value).FirstOrDefault())).ReverseMap(); 
            CreateMap<User, ResponseAuthenticateDto>()
                .ForMember(ar => ar.RoleName, opt => opt.MapFrom(usr => usr.Role.Name))
                .ForMember(ar => ar.Avatar, opt => opt.MapFrom(opt => opt.UserMetas.Select(x => x.Value).FirstOrDefault())).ReverseMap();
            CreateMap<User, ResponsUsersDto>().ForMember(x => x.QrCode, opt => opt.MapFrom(usr => usr.QRCode.Token))
                .ForMember(ar => ar.Avatar, opt => opt.MapFrom(opt => opt.UserMetas.Select(x => x.Value).FirstOrDefault()))
                .ForMember(x => x.RoleName, opt => opt.MapFrom(usr => usr.Role.Name)).ReverseMap(); 
            CreateMap<UserActions, ResponseListofActionUsersDto>()
                .ForMember(rla => rla.Actions, opt => opt.MapFrom(usr => usr.Actions.Select(act => new ActionDto { Entry = act.Entry, Exit = act.Exit })
                .ToList())).ReverseMap();
            CreateMap<Model.Entity.Action, ResponsePostmarkerQRcodeDto>().ConstructUsing(act => new ResponsePostmarkerQRcodeDto { Entry = (act.Entry.HasValue)? act.Entry.Value.ToString("MM/dd/yyyy HH:mm") : null, Exit = (act.Exit.HasValue) ? act.Exit.Value.ToString("MM/dd/yyyy HH:mm"): null }).ReverseMap();
            CreateMap<RequestRegisterDto, User>();
            CreateMap<RequestUpdateUserDto, User>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;
                        return true;
                    }
                ));
        }
    }
}