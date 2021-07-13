using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.EfStuff;
using MyProject.EfStuff.Model;
using MyProject.EfStuff.Repositories;
using MyProject.Models;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject
{
    public class Startup
    {
        public const string AuthMethod = "AuthMethod";
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetValue<string>("connectionString");
            services.AddDbContext<CafeDbContext>(x => x.UseSqlServer(connectionString));

            services.AddAuthentication(AuthMethod)
                .AddCookie(AuthMethod, options =>
                {
                    options.Cookie.Name = "AuthCookie";
                    options.LoginPath = "/User/Login";
                });

            RegistrationMapper(services);
            RegistrationRepositories(services);
            RegistrationService(services);

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
        }

        private void RegistrationService(IServiceCollection services)
        {
            services.AddScoped<IUserService>(diContainer =>
              new UserService(
                  diContainer.GetService<IUserRepository>(),
                  diContainer.GetService<IHttpContextAccessor>()
              ));

            services.AddScoped<IPathHelper>(diConteiner =>
            new PathHelper(
                  diConteiner.GetService<IWebHostEnvironment>()
                ));
        }

        private void RegistrationRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository>(diContainer =>
                new UserRepository(diContainer.GetService<CafeDbContext>()));
        }

        private void RegistrationMapper(IServiceCollection services)
        {
            var configExpression = new MapperConfigurationExpression();

            MapBoth<User, RegistrationViewModel>(configExpression);

            var mapperConfiguration = new MapperConfiguration(configExpression);
            var mapper = new Mapper(mapperConfiguration);
            services.AddScoped<IMapper>(c => mapper);
        }

        public void MapBoth<Type1, Type2>(MapperConfigurationExpression configExpression)
        {
            configExpression.CreateMap<Type1, Type2>();
            configExpression.CreateMap<Type2, Type1>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<LocalizationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
