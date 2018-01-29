using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repository.Demo.NetCoreWebApp.Data;
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
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
