using Business.Abstract;
using Business.Concrete;
using Business.Helper.AutoMapperProfiles;
using Bussiness.Abstract;
using Bussiness.Concrete;
using Bussiness.Helper.AutoMapperProfiles;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {


            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Token:SigningKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                        .AddJwtBearer(x =>
                        {
                            x.RequireHttpsMetadata = false;
                            x.SaveToken = true;
                            x.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey((key)),
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                        });

            services.AddDbContext<DataAccess.Concrete.EntityFramework.DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyDatabase")));


            #region Bussiness Scoped
            services.AddScoped<IApplicationUserService, ApplicationUserManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<IMessageService, MessageManager>();
            #endregion

            #region DataAccess Scoped
            services.AddScoped<IApplicationUserDal, EfApplicationUserDal>();
            services.AddScoped<IApplicationUserRoleDal, EfApplicationUserRoleDal>();
            services.AddScoped<ICityDal, EfCityDal>();
            services.AddScoped<ICountryDal, EfCountryDal>();
            services.AddScoped<IEmailConfirmedDal, EfEmailConfirmedDal>();
            services.AddScoped<IImageDal, EfImageDal>();
            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<INotificationDal, EfNotificationDal>();


            #endregion

            services.AddAutoMapper(typeof(ApplicationUserDTO));

            services.AddAutoMapper(c => c.AddProfile<ApplicationUserProfile>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<CountryProfile>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<CityProfile>(), typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MessageProfile>(), typeof(Startup));


            services.AddAutoMapper(typeof(Startup));

            services.AddRazorPages();
            services.AddHttpContextAccessor();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

    }
}
