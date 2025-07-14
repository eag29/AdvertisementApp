using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Common;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Service
{
    public class AdvertisementService : Service<CreateAdvertisementDto, UpdateAdvertisementDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public AdvertisementService(IMapper mapper, IUow uow, IValidator<CreateAdvertisementDto> creaeteValidator, IValidator<UpdateAdvertisementDto> updateValidator) : base(mapper, uow, creaeteValidator, updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status, x => x.CreatedDate, Common.Enums.OrderByType.Desc);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Succes, dto);
        }
    }
}
