using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Common.Enums;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using EmirAliGirgin.AdvertisementApp2.UI.Extensions;
using EmirAliGirgin.AdvertisementApp2.UI.Models;
using EmirAliGirgin.AdvertisementApp2.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmirAliGirgin.AdvertisementApp2.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IAppUserService _appUserService;
        private readonly IValidator<UserCreateModel> _createValidator;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> validator, IMapper mapper, IAppUserService appUserService)
        {
            _genderService = genderService;
            _createValidator = validator;
            _mapper = mapper;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _createValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }
        //Emirali_29
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType == Common.ResponseType.Succes)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);

                var claims = new List<Claim>();
                if (roleResult.ResponseType == Common.ResponseType.Succes)
                {
                    foreach (var item in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item.Definition));
                    }
                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));
                var claimsıdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsıdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);

            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
