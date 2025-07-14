using AutoMapper;
using EmirAliGirgin.AdvertisementApp2.Business.DependecyReseolves.Microsoft;
using EmirAliGirgin.AdvertisementApp2.Business.Helper;
using EmirAliGirgin.AdvertisementApp2.UI.Mappings.AutoMapper;
using EmirAliGirgin.AdvertisementApp2.UI.Models;
using EmirAliGirgin.AdvertisementApp2.UI.ValidationRules;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EmirAliGirgin.AdvertisementApp2.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateValidator>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.Cookie.Name = "AdvertisementCookie";
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.ExpireTimeSpan = TimeSpan.FromDays(100);
                opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/SignIn");
                //opt.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccesDenied");
                //opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/AccesDenied");
            });

            services.AddControllersWithViews();

            var profiles = ProfileHelper.GetProfiles();
            profiles.Add(new UserCreateModelProfile());

            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfiles(profiles);
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapperConfiguration);
            services.AddSingleton<IMapper>(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
