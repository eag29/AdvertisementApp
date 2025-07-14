using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using FluentValidation;

namespace EmirAliGirgin.AdvertisementApp2.Business.Service
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IUow uow, IValidator<ProvidedServiceCreateDto> creaeteValidator, IValidator<ProvidedServiceUpdateDto> updateValidator) : base(mapper, uow, creaeteValidator, updateValidator)
        {
        }
    }
}
