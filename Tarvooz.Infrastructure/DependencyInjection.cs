using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tarvooz.Application.Abstractions;
using Tarvooz.Infrastructure.Persistance;

namespace Tarvooz.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(option =>
            {
                option.UseNpgsql("DefaultConnection");
            });

            return services;
        }
    }
}
