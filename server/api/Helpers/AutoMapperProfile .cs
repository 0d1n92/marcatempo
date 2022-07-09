using AutoMapper;
using api.Response;
using api.Model.Entity;
namespace api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponse>().ReverseMap();
            CreateMap<Activity, PostmarkerQRcodeResponse>();
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