using AutoMapper;
using api.DTOs;
using api.Model.Entity;
namespace api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponseDto>().ReverseMap();
            CreateMap<Action, PostmarkerQRcodeResponseDto>();
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