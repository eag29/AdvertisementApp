using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.UI.Models;
using EmirAliGirgin.AdvertisementApp2.UI.ValidationRules;

namespace EmirAliGirgin.AdvertisementApp2.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile: Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
