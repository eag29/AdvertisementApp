﻿using EmirAliGirgin.AdvertisementApp2.Common;
using EmirAliGirgin.AdvertisementApp2.Dtos.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity

    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto createDto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
    }
}
