using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.UserCases.Commands
{
    public class SendVerificationToUserCommand:IRequest<ResponseModel>
    {
        public string Email { get; set; }
    }
}
