using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.UserCases.Commands
{
    public class RegisterUserCommand:IRequest<ResponseModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SentPassword { get; set; }
    }
}
