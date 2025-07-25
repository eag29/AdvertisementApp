﻿using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;

namespace EmirAliGirgin.AdvertisementApp2.Dtos
{
    public class AdvertisementAppUserCreateDto : IDto
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public int WorkExperience { get; set; }
        public DateTime? EndDate { get; set; }
        public string CvPath { get; set; }
    }
}
