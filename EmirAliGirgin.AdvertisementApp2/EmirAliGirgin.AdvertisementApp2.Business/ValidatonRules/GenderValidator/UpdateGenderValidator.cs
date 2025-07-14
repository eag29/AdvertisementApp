using EmirAliGirgin.AdvertisementApp2.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.GenderValidator
{
    public class UpdateGenderValidator: AbstractValidator<GenderUpdateDto>
    {
        public UpdateGenderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
