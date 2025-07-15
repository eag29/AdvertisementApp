using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;

namespace EmirAliGirgin.AdvertisementApp2.Dtos
{
    public class AdvertisementAppUserListDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUserListDto AppUser { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public int WorkExperience { get; set; }
        public DateTime? EndDate { get; set; }
        public string CvPath { get; set; }
    }
}
