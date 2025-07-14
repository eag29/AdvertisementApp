using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Extensions;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Common;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.Dtos.AppRoleDtos;
using EmirAliGirgin.AdvertisementApp2.Entities;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.Business.Service
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IValidator<AppUserCreateDto> _validator;
        private readonly IValidator<AppUserLoginDto> _loginvalidator;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public AppUserService(IMapper mapper, IUow uow, IValidator<AppUserCreateDto> creaeteValidator, IValidator<AppUserUpdateDto> updateValidator, IValidator<AppUserLoginDto> loginvalidator) : base(mapper, uow, creaeteValidator, updateValidator)
        {
            _validator = creaeteValidator;
            _mapper = mapper;
            _uow = uow;
            _loginvalidator = loginvalidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleID)
        {
            var result = _validator.Validate(dto);
            if (result.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                user.AppUserRoles = new List<AppUserRole>();
                user.AppUserRoles.Add(new AppUserRole()
                {
                    AppUsers = user,
                    AppRoleId = roleID,
                });

                await _uow.GetRepository<AppUser>().CreateAsync(user);
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Succes, dto);
            }
            return new Response<AppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }
        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var result = _loginvalidator.Validate(dto);
            if (result.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if (user != null)
                {
                    var data = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Succes, data);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı boş veya hatalı");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz");
        }
        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if (roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "Herhangi bir rol bulunamadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Succes, dto);
        }
    }
}
