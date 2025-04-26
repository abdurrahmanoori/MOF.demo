using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MOF.Application.IRepositories;
using MOF.Application.IRepositories.Products;
using MOF.Infra.Data;
using MOF.Infra.Repositories;
using MOF.Infra.Repositories.Products;

namespace MOF.Infra
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection ConfigureInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DBCS")));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
