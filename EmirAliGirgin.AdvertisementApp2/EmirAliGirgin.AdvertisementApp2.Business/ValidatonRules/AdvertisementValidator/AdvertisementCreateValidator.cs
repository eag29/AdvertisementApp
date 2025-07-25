﻿using EmirAliGirgin.AdvertisementApp2.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.AdvertisementValidator
{
    public class AdvertisementCreateValidator : AbstractValidator<CreateAdvertisementDto>
    {
        public AdvertisementCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.CreatedDate).NotEmpty();
        }
    }
}
