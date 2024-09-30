using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.ProductCases.Commands
{
    public class DeleteProductByIdCommand:IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
