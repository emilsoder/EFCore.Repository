using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repository.Demo.NetCoreWebApp.Data;
using EFCore.Repository.Demo.NetCoreWebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.Repository.Demo.NetCoreWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddConferenceApiDbContext();
            services.AddTransient<IRepository, RepositoryBase>();
            services.AddTransient<IMovieService, MovieService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) => {
                await next();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvcWithDefaultRoute();

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }

    public static class StartupConfigurationBuilder
    {
        public static IServiceCollection AddConferenceApiDbContext(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient(DbContextImplementationFactory);
        }

        private static DbContext DbContextImplementationFactory(IServiceProvider serviceProvider)
        {
            var db = new FakeDatabase(new DbContextOptionsBuilder().UseInMemoryDatabase("FakeDatabase").Options);
            DbSeeder.SeedDatabase(db);
            return db;
        }
    }
}
