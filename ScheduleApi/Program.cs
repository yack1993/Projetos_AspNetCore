using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;



using Microsoft.AspNetCore;
using Autofac.Extensions.DependencyInjection;

namespace ScheduleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
        .ConfigureAppConfiguration((builderContext, config) =>
        {
            IHostingEnvironment env = (IHostingEnvironment)builderContext.HostingEnvironment;
            config.AddJsonFile("autofacHlg.json");
            /*if (env.IsDevelopment())
            {
                config.AddJsonFile("autofacHlg.json");
            }*/
            /* else if (env.IsProduction())
             {
                 config.AddJsonFile("autofacHlg.json");
             }*/
            config.AddEnvironmentVariables();
        })
             .ConfigureServices(services => services.AddAutofac());


    }
}
