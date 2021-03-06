using AutoMapper;
using api.DTOs;
using api.Model.Entity;
using System.Linq;

namespace api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponseDto>()
                .ForMember(ar => ar.RoleName, opt => opt.MapFrom(usr => usr.Role.Name))
                .ForMember(ar => ar.Avatar, opt => opt.MapFrom(opt => opt.UserMetas.Select(x => x.Value).FirstOrDefault())).ReverseMap();
            CreateMap<User, ResponsUsersDto>().ForMember(x => x.QrCode, opt => opt.MapFrom(usr => usr.QRCode.token))
                .ForMember(ar => ar.Avatar, opt => opt.MapFrom(opt => opt.UserMetas.Select(x => x.Value).FirstOrDefault()))
                .ForMember(x => x.RoleName, opt => opt.MapFrom(usr => usr.Role.Name)).ReverseMap(); 
            CreateMap<User, ResponseListofActionUsersDto>()
                .ForMember(rla => rla.Actions, opt => opt.MapFrom(usr => usr.Activities.Select(act => new ActionDto { Name = usr.FirstName, Surname = usr.LastName, IsPresent = act.IsPresent, Entry = act.Entry, Exit = act.Exit })
                .ToList())).ReverseMap();
            CreateMap<Model.Entity.Action, PostmarkerQRcodeResponseDto>().ConstructUsing(act => new PostmarkerQRcodeResponseDto { Entry = act.Entry, Exit = act.Exit}).ReverseMap();
            CreateMap<RegisterRequestDto, User>();
            CreateMap<UpdateRequestDto, User>()
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