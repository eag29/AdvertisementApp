using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Mappings.AutoMapper
{
    public class AdvertisementProfile: Profile
    {
        public AdvertisementProfile()
        {
            CreateMap<CreateAdvertisementDto, Advertisement>().ReverseMap();
            CreateMap<UpdateAdvertisementDto, Advertisement>().ReverseMap();
            CreateMap<AdvertisementListDto, Advertisement>().ReverseMap();
        }
    }
}
