using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Entities
{
    public class AppUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
