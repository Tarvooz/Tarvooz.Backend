using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Queries
{
    public class GetProductsByCategoryName:IRequest<IEnumerable<Product>>
    {
        public string CategoryName { get; set; }
    }
}
