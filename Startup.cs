using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using XF1Api.Repositories;
using XF1Api.Data;

namespace XF1Api
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
            services.AddDbContext<XFIAOnlinedatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("XFIAOnlinedatabaseConnection")));

            services.AddScoped<IXFIAOnlinedatabaseContext>(provider => provider.GetService<XFIAOnlinedatabaseContext>());
            services.AddScoped<IEscuderiaRepository, EscuderiaRepository>();
            services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
            services.AddScoped<IJugadorRepository, JugadorRepository>();
            services.AddScoped<ICarreraRepository, CarreraRepository>();
            services.AddScoped<IEquipoRepository, EquipoRepository>();
            services.AddScoped<IPilotoRepository, PilotoRepository>();

            services.AddControllers();

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            

        }
    }
}
