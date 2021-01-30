using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Book_Store1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var WebHost = CreateHostBuilder(args).Build();
            RunMigrations(WebHost);
            
            WebHost.Run();
        }

        private static void RunMigrations(IHost webHost)
        {
            using(var scope=webHost.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookStore1DbContext>();

                db.Database.Migrate();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
