using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Mappings.AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Service;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Helper
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>()
            {
                new AdvertisementProfile(),
                new GenderProfile(),
                new ProvidedServiceProfile(),
                new AppUserProfile(),
                new AppRoleProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile()
            };

        }
    }
}
