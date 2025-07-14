using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using FluentValidation;

namespace EmirAliGirgin.AdvertisementApp2.Business.Service
{
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IMapper mapper, IUow uow, IValidator<GenderCreateDto> creaeteValidator, IValidator<GenderUpdateDto> updateValidator) : base(mapper, uow, creaeteValidator, updateValidator)
        {
        }
    }
}
