using System;
using System.Collections.Generic;

namespace EmirAliGirgin.AdvertisementApp2.Entities
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
