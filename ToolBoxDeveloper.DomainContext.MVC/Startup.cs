using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using ToolBoxDeveloper.DomainContext.Domain.Contracts.Settings;
using ToolBoxDeveloper.DomainContext.Domain.Settings;
using ToolBoxDeveloper.DomainContext.IoC;
using ToolBoxDeveloper.DomainContext.MVC.Extensions;

namespace ToolBoxDeveloper.DomainContext.MVC
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
            services.AddControllersWithViews();

            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));

            services.AddSingleton<IDatabaseSettings>(sp =>sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddInjectionConfiguration();

            services.AddHealthChecksConfiguration(Configuration);

            services.AddAuthenticationConfiguration();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(typeof(InjectionConfiguration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSerilogRequestLogging();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecksConfiguration();

            app.UseEndpoints(endpoints =>
            {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
