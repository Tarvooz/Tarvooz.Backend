using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarvooz.Application.Abstractions;
using Tarvooz.Infrastructure.Persistance;

namespace Tarvooz.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(option =>
            {
                option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
