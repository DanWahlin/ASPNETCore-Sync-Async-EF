using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ASPNETCore_Sync_Async_EF.Repository;

namespace ASPNETCore_Sync_Async_EF
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Add SQL Server support
            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<CustomersDbContext>(options =>
            //       options.UseSqlServer(Configuration.GetConnectionString["CustomersSqlServerConnectionString")));

            //Add SqLite support
            services.AddEntityFrameworkSqlite()
                .AddDbContext<CustomersDbContext>(options =>
                   options.UseSqlite(Configuration.GetConnectionString("CustomersSqliteConnectionString")));
            
            // Add framework services.
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICustomersRepositoryAsync, CustomersRepositoryAsync>();
            services.AddTransient<CustomersDbSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            CustomersDbSeeder customersDbSeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowAnyOrigin");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            customersDbSeeder.SeedAsync(app.ApplicationServices).Wait();
        }
    }
}
