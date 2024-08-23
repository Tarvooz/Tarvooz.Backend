using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.Services.PasswordServices
{
    public interface IPasswordService
    {
        public PasswordModel HashPassword(string password);
        public bool CheckPassword(string password,PasswordModel passwordModel);
    }
}
