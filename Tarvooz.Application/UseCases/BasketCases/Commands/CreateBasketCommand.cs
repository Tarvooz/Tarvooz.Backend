using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.BasketCases.Commands
{
    public class CreateBasketCommand:IRequest<ResponseModel>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set;}
    }
}
