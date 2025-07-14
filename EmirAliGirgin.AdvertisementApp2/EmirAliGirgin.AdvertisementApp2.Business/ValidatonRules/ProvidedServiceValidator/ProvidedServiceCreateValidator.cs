using EmirAliGirgin.AdvertisementApp2.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.ProvidedValitor
{
    public class ProvidedServiceCreateValidator: AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
