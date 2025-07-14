using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.GenderValidator
{
    public class CreateGenderValidator : AbstractValidator<GenderCreateDto>
    {
        public CreateGenderValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
