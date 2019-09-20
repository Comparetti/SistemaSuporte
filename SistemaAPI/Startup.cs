using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SistemaInfra.Data;
using SistemaInfra.Repository;
using SuporteCore.Interfaces.Repository;
using SuporteCore.Interfaces.Service;
using SuporteCore.Service;

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
            #region Dependency Injection
            //Repository
            services.AddScoped<IPhoebusRepository, PhoebusRepository>();
            services.AddScoped<IIntermeioRepository, IntermeioRepository>();
            services.AddScoped<IAnaliseRepository, AnaliseRepository>();
            //Service
            services.AddScoped<IPhoebusService, PhoebusService>();
            services.AddScoped<IIntermeioService, IntermeioService>();
            services.AddScoped<IAnaliseService, AnaliseService>();
            #endregion

            services.AddDbContext<SuporteContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
