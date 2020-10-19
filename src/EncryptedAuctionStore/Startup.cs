using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.IO;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using EncryptedAuctionStore.Middlewares;
using EncryptedAuctionStore.Database;
using EncryptedAuctionDatatypes;
using System.Threading.Tasks;

namespace EncryptedAuctionStore
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
            services.AddDbContext<DBContext>(options => {

                options.UseMySql(Configuration.GetConnectionString("Db"),
                    mySqlOptions => mySqlOptions
                        .CharSet(CharSet.Utf8)
                        .EnableRetryOnFailure(5)
                        // replace with your Server Version and Type
                        .ServerVersion(new Version(8, 0, 18), ServerType.MySql));
                });
            var storeObj = new StoreBase();
            Configuration.GetSection("Store").Bind(storeObj);
            services.AddSingleton<StoreBase>(storeObj);
            services.AddHealthChecks();
            services.Configure<KestrelServerOptions>(
                Configuration.GetSection("Kestrel"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DBContext db, StoreBase store)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            db.Database.EnsureCreated();

            var seedFile = "seed.json";
            if (File.Exists(seedFile))
            {
                Registrator reg = new Registrator(Configuration, store);
                var data = File.ReadAllText(seedFile);
                Seeder.Seedit(reg, data, db);
            }
            app.UseMiddleware<RequestLoggingMiddleware>();
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/online");
            });
        }
    }
}
