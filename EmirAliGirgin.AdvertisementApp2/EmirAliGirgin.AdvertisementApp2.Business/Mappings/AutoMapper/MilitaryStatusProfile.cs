using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Dtos.MilitaryStatus;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Mappings.AutoMapper
{
    public class MilitaryStatusProfile : Profile
    {
        public MilitaryStatusProfile()
        {
            CreateMap<MilitaryStatusCreateDto, MilitaryStatus>().ReverseMap();
            CreateMap<MilitaryStatusUpdateDto, MilitaryStatus>().ReverseMap();
            CreateMap<MilitaryStatusListDto, MilitaryStatus>().ReverseMap();
        }
    }
}
