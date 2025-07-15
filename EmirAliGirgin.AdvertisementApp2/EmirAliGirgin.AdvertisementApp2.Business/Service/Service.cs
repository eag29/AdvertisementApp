using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Extensions;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Common;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Entities;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Service
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IUow _uow;
        private readonly IValidator<CreateDto> _createValidator;
        private readonly IValidator<UpdateDto> _updateValidator;

        public Service(IMapper mapper, IUow uow, IValidator<CreateDto> creaeteValidator, IValidator<UpdateDto> updateValidator)
        {
            _mapper = mapper;
            _uow = uow;
            _createValidator = creaeteValidator;
            _updateValidator = updateValidator;
        }
        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var values = await _uow.GetRepository<T>().GetAllAsync();
            var dtoList = _mapper.Map<List<ListDto>>(values);
            return new Response<List<ListDto>>(ResponseType.Succes, dtoList);
        }
        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var findedId = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if (findedId == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}'ye sahip data bulunamadı");
            }
            var data = _mapper.Map<IDto>(findedId);
            return new Response<IDto>(ResponseType.Succes, data);
        }
        public async Task<IResponse> RemoveAsync(int id)
        {
            var findedId = await _uow.GetRepository<T>().FindByAsync(id);
            if (findedId == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id}'ye sahip data bulunamadı");
            }
            _uow.GetRepository<T>().Remove(findedId);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Succes);
        }
        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto createDto)
        {
            var result = _createValidator.Validate(createDto);
            if (result.IsValid)
            {
                var createdEntity = _mapper.Map<T>(createDto);
                await _uow.GetRepository<T>().CreateAsync(createdEntity);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Succes, createDto);
            }
            return new Response<CreateDto>(createDto, result.ConvertToCustomValidationError());
        }
        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto)
        {
            var result = _updateValidator.Validate(updateDto);
            if (result.IsValid)
            {
               var unchangedValue = await _uow.GetRepository<T>().FindByAsync(updateDto.Id);
                if (unchangedValue == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"{updateDto.Id}'ye sahip data bulunamadı");
                }
                var updatedValue =  _mapper.Map<T>(updateDto);
                _uow.GetRepository<T>().Update(updatedValue, unchangedValue);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Succes, updateDto);
            }
            return new Response<UpdateDto>(updateDto, result.ConvertToCustomValidationError());
        }
    }
}
