using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.BasketCases.Queries
{
    public class GetUserBasketsQuery:IRequest<IEnumerable<Product>>
    {
        public Guid UserId { get; set; }
    }
}
