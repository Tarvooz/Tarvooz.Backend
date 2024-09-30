using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Queries
{
    public class GetProductsBySearchPatternQuery:IRequest<IEnumerable<Product>>
    {
        public string SearchPattern {  get; set; }
    }
}
