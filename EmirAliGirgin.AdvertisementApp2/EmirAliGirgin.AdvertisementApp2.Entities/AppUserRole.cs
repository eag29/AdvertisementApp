using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Entities
{
    public class AppUserRole : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUsers { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRoles { get; set; }
    }
}
