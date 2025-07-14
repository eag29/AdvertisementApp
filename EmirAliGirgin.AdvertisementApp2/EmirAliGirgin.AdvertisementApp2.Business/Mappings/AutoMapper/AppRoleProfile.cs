using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Dtos.AppRoleDtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Mappings.AutoMapper
{
    public class AppRoleProfile: Profile
    {
        public AppRoleProfile()
        {
            CreateMap<CreateAppRoleDto, AppRole>().ReverseMap();
            CreateMap<AppRoleUpdateDto, AppRole>().ReverseMap();
            CreateMap<AppRoleListDto, AppRole>().ReverseMap();
        }
    }
}
