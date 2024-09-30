using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Queries
{
    public class GetUserAllProductsQuery:IRequest<IEnumerable<Product>>
    {
        public Guid UserId { get; set; }
    }
}
