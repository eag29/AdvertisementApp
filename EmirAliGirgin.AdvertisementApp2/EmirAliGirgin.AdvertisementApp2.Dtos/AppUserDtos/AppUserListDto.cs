using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Dtos
{
    public class AppUserListDto: IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public GenderListDto Gender { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
