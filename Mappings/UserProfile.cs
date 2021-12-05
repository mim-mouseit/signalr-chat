using AutoMapper;
using SignalrWebApplication_lastexam.Data.Entities;
using SignalrWebApplication_lastexam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrWebApplication_lastexam.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserViewModel>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(x => x.UserName));
            CreateMap<UserViewModel, AppUser>();
        }
    }
}
