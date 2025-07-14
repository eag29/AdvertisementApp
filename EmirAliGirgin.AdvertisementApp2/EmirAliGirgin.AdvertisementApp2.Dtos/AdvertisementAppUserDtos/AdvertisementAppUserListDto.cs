using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Dtos.MilitaryStatus;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;

namespace EmirAliGirgin.AdvertisementApp2.Dtos
{
    public class AdvertisementAppUserListDto : IDto
    {
        public int AdvertisementAppUserId { get; set; }
        public Advertisement Advertisement { get; set; }
        public int AdvertisementId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public AdvertisementAppUserStatus AdvertisementAppUserStatus { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public int WorkExperience { get; set; }
        public DateTime EndDate { get; set; }
        public string CvFile { get; set; }
    }
}
