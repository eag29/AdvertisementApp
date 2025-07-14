using EmirAliGirgin.AdvertisementApp2.Common.Enums;
using EmirAliGirgin.AdvertisementApp2.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace EmirAliGirgin.AdvertisementApp2.UI.Models
{
    public class AdvertisementAppUserCreateModel
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public int AdvertisementAppUserId { get; set; } = (int)AdvertisementAppUserStatusType.Basvurdu;
        public int MilitaryStatusId { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }
    }
}
