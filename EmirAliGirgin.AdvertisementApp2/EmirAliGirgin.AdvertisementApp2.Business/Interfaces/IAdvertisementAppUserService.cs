using EmirAliGirgin.AdvertisementApp2.Common;
using EmirAliGirgin.AdvertisementApp2.Common.Enums;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementId, AdvertisementAppUserStatusType type);
    }
}
