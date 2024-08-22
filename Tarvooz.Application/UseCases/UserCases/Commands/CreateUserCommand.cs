using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.UserCases.Commands
{
    public class CreateUserCommand:IRequest<ResponseModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
