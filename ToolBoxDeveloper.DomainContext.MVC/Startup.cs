using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog;
using ToolBoxDeveloper.DomainContext.MVC.CustomHealthChecks;
using ToolBoxDeveloper.DomainContext.Domain.Contracts;
using ToolBoxDeveloper.DomainContext.Domain.Settings;
using ToolBoxDeveloper.DomainContext.IoC;

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

            services.Configure<DatabaseSettings>(
                      Configuration.GetSection(nameof(DatabaseSettings))
              );

            services.AddSingleton<IDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            services.AddInjectionConfiguration();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
            {
                opt.LoginPath = new PathString("/Autentication/Index");
                opt.LogoutPath = new PathString("/Autentication/Logout");
                opt.Cookie = new CookieBuilder()
                {
                    Name = "DomainContext",
                };
            });

            var configurationSection = Configuration.GetSection(nameof(DatabaseSettings));
            DatabaseSettings appSettings = new DatabaseSettings();
            ConfigurationBinder.Bind(configurationSection, appSettings);

            services.AddHealthChecks()
                .AddMongoDb(mongodbConnectionString: appSettings.ConnectionString,
                name: "Instancia mongoDB")
                .AddCheck<DependeciesValidadeHealthCheck>("Health Checks customizavel");

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.SetEvaluationTimeInSeconds(5);
                setup.MaximumHistoryEntriesPerEndpoint(10);
                setup.AddHealthCheckEndpoint("API com Health Checks", "/health");
            }).AddInMemoryStorage(); ;

            services.AddHealthChecksUI();


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

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
