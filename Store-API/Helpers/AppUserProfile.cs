using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Store_API.Models;
using Store_Shared.Dto;
using Store_Shared.Models;

namespace Store_API.Helpers
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            this.CreateMap<ApplicationUser, RegisterModel>();
            this.CreateMap<RegisterModel, ApplicationUser>();
            this.CreateMap<ApplicationUser, AuthModel>();
            this.CreateMap<ApplicationUser, ApplicationUser>();
            this.CreateMap<EditUserModel, RegisterModel>();
            this.CreateMap<ApplicationUser, UserModel>();
        }
    }
}
