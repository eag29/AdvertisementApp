using System.Collections.Generic;

namespace EmirAliGirgin.AdvertisementApp2.Entities
{
    public class MilitaryStatus: BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
