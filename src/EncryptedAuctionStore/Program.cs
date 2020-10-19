using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using EncryptedAuctionStore.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EncryptedAuctionStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var port = config.GetValue<int>("Port");
            CreateHostBuilder(args, port).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args,int port) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => 
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel((context, serverOptions) =>
                    {
                        serverOptions.ListenAnyIP(port, listenOptions => 
                        {
                            listenOptions.UseConnectionLogging();
                        });
                        serverOptions.ConfigureEndpointDefaults(listenOptions =>
                        {
                            // Configure endpoint defaults
                        });
                        //serverOptions.ConfigureHttpsDefaults(listenOptions =>
                        //{
                        //    listenOptions.SslProtocols = SslProtocols.Tls12;
                        //});
                    })
                    .UseStartup<Startup>();
                });

    }
}
