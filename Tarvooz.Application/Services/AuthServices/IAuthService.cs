using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateToken(User user);
    }
}
