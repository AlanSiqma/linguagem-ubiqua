using Devtoolkit.LinguagemUbiqua.MVC.Extension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Devtoolkit.LinguagemUbiqua.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ASPNETCORE_ENVIRONMENT =
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (ASPNETCORE_ENVIRONMENT == null)
                DotEnvExtention.Load();


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
