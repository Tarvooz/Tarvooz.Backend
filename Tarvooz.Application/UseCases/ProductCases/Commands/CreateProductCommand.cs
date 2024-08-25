using MediatR;
using Microsoft.AspNetCore.Http;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.ProductCases.Commands
{
    public class CreateProductCommand:IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile Image { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
