using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoPole.Core.Services;
using InfoPole.Data;
using InfoPole.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoPole
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InfoPoleDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvcCore()
                .AddJsonFormatters();

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

            services.AddRouting();
            services.AddCors();


            services.AddTransient<IServerCacheService, ServerCacheService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors(builder =>
            {
                builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
            name: "default",
            template: "{controller=Main}/{action=Get}");
            });

        }
    }
}
