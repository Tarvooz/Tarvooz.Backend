using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tarvooz.Application.Services.AuthServices;
using Tarvooz.Application.Services.EmailServices;
using Tarvooz.Application.Services.PasswordServices;

namespace Tarvooz.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ISendEmailService, SendEmailService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
