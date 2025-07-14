using EmirAliGirgin.AdvertisementApp2.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmirAliGirgin.AdvertisementApp2.UI.Models
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public SelectList Genders { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
