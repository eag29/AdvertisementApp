using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.AppUserValidator;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Mappings.AutoMapper
{
    public class AppUserProfile: Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserCreateDto, AppUser>().ReverseMap();
            CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
        }
    }
}
