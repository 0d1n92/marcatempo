﻿using AutoMapper;
using api.DTOs;
using api.Model.Entity;
using System.Linq;

namespace api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, AuthenticateResponseDto>().ForMember(x => x.RoleName, opt => opt.MapFrom(c => c.Role.Name)).ReverseMap();

            CreateMap<User, ResponseListofActionUsersDto>().ForMember(x => x.Actions, opt => opt.MapFrom(usr => usr.Activities.Select(act => new ActionDto { Name = usr.FirstName, Surname = usr.LastName, IsPresent = act.IsPresent, Entry = act.Entry, Exit = act.Exit }).ToList())).ReverseMap();
            CreateMap<Model.Entity.Action, PostmarkerQRcodeResponseDto>().ReverseMap();
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