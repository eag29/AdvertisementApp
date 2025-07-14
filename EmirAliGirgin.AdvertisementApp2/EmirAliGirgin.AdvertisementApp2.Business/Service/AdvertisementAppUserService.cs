using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Extensions;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Common;
using EmirAliGirgin.AdvertisementApp2.Common.Enums;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Dtos.AdvertisementAppUserStatusDtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Service
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IValidator<AdvertisementAppUserCreateDto> _validator;
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IValidator<AdvertisementAppUserCreateDto> validator, IUow uow, IMapper mapper)
        {
            _validator = validator;
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId & x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Succes, dto);
                }
                List<CustomValidationError> erros = new List<CustomValidationError> { new CustomValidationError { ErrorMessage = "Daha önce başvurulan bu ilana başvurulamaz", PropertyName = "" } };
            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserStatusListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus).Include(x => x.MilitaryStatus).Include(x => x.AppUser).Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserStatusListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementId, AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();
            var enttiy = await query.FirstOrDefaultAsync(x => x.Id == advertisementId);
            enttiy.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();
        }
    }
}
