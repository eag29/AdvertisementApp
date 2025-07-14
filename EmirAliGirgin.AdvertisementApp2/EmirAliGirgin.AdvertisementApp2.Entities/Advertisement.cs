using System;
using System.Collections.Generic;

namespace EmirAliGirgin.AdvertisementApp2.Entities
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
