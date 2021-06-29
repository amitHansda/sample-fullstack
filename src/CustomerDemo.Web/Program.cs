using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDemo.Web.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CustomerDemo.Web
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    var serviceprovider = scope.ServiceProvider;
                    var databaseContext = serviceprovider.GetRequiredService<ApplicationDbContext>();
                    
                    if(databaseContext!=null){
                        await databaseContext.Database.MigrateAsync();
                        Console.WriteLine("Database migrated successfully");
                        var seedService = serviceprovider.GetRequiredService<ISeedService>();
                        await seedService.RunDepartmentSeedAsync();

                    }


                    
                }

                await host.RunAsync();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error starting the server:{0} {1}",ex.Message,ex.StackTrace);
                return 1;
            }
            
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
