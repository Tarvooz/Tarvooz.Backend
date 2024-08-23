using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.UserCases.Commands
{
    public class LogUserInCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
