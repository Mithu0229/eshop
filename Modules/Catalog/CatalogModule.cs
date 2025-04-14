using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Catalog.Data.Seed;
using Shared.Data.Seed;
namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {

            // Data - Infrastructure services

            services.AddDbContext<CatalogDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("Database")));
            //var connectionString = configuration.GetConnectionString("Database");
            //services.AddDbContext<CatalogDbContext>((sp, options) =>
            //{
            //    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            //    options.UseNpgsql(connectionString);
            //});

            services.AddScoped<IDataSeeder, CatalogDataSeeder>();
            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // 1. Use Api Endpoint services

            // 2. Use Application Use Case services

            // 3. Use Data - Infrastructure services  
            app.UseMigration<CatalogDbContext>();
            return app;
        }
    }
}
