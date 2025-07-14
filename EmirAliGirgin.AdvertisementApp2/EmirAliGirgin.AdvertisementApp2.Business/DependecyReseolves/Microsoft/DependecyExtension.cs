using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.Interfaces;
using EmirAliGirgin.AdvertisementApp2.Business.Service;
using EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.AdvertisementAppUserValidator;
using EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.AdvertisementValidator;
using EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.AppUserValidator;
using EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.GenderValidator;
using EmirAliGirgin.AdvertisementApp2.Business.ValidatonRules.ProvidedValitor;
using EmirAliGirgin.AdvertisementApp2.DAL.Contexts;
using EmirAliGirgin.AdvertisementApp2.DAL.UnitOfWork;
using EmirAliGirgin.AdvertisementApp2.Dtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmirAliGirgin.AdvertisementApp2.Business.DependecyReseolves.Microsoft
{
    public static class DependecyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, CreateGenderValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, UpdateGenderValidator>();

            services.AddTransient<IValidator<UpdateAdvertisementDto>, AdvertisementUpdateValidator>();
            services.AddTransient<IValidator<CreateAdvertisementDto>, AdvertisementCreateValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateValiator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginCreateValidator>();

            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAppUserService, AppUserService>();
        }
    }
}
