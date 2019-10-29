using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SistemaInfra.Data;
using SistemaInfra.Repository;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Service;
using SuporteCore.Util;
using System;
using System.Text;

namespace SistemaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            #region AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DTOMapperProfile());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Dependency Injection
            //Repository
            services.AddScoped<IExtratoRepository, ExtratoRepository>();
            services.AddScoped<IPosRepository, PosRepository>();
            services.AddScoped<IPhoebusRepository, PhoebusRepository>();
            services.AddScoped<IIntermeioRepository, IntermeioRepository>();
            services.AddScoped<IAnaliseRepository, AnaliseRepository>();
            services.AddScoped<IExtratoRepository, ExtratoRepository>();
            //Service
            services.AddScoped<IExtratoService, ExtratoService>();
            services.AddScoped<IExtratoService, ExtratoService>();
            services.AddScoped<IPosService, PosService>();
            services.AddScoped<IPhoebusService, PhoebusService>();
            services.AddScoped<IIntermeioService, IntermeioService>();
            services.AddScoped<IAnaliseService, AnaliseService>();
            #endregion


            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHangfireServer();

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SuporteContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<SuporteContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #region JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            IPhoebusService _phoebusService,
            IIntermeioService _intermeioService,
            IAnaliseService _analiseService,
            IPosService _posService,
            IExtratoService _extratoService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //  app.UseHttpsRedirection();
            app.UseHangfireDashboard();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseMvc();

            #region Background Jobs HangFire
            BackgroundJob.Schedule(() => _phoebusService.RequestPhoebus(DateTime.Now, "00:00:00", "23:59:59"), TimeSpan.FromMinutes(60));
            RecurringJob.AddOrUpdate(() => _intermeioService.GetAllBaseIntermeio(), Cron.Daily(12, 30));
            RecurringJob.AddOrUpdate(() => _analiseService.ValidationAnalise(), Cron.Daily(12, 30));
            RecurringJob.AddOrUpdate(() => _posService.RequestPosByIntermeio(), Cron.Daily(12, 30));
            RecurringJob.AddOrUpdate(() => _extratoService.ValidationAluguel(), Cron.Daily(12, 30));
            #endregion
        }
    }
}
