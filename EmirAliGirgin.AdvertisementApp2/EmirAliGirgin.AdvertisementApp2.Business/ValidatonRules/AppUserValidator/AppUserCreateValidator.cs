using EmirAliGirgin.AdvertisementApp2.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.AppUserValidator
{
    public class AppUserCreateValidator: AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
        }
    }
}
