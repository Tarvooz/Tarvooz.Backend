using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.BasketCases.Queries;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.BasketCases.Handlers.QueryHandlers
{
    public class GetUserBasketsQueryHandler : IRequestHandler<GetUserBasketsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetUserBasketsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetUserBasketsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Basket> baskets=_applicationDbContext.Baskets.Where(b=>b.User.Id==request.UserId).ToList();

                List<Guid> basketIds = new List<Guid>();

                for (int i = 0; i < baskets.Count; i++)
                {
                    basketIds.Add(baskets[i].ProductId);
                }

                return await _applicationDbContext.Products.Where(p => basketIds.Contains(p.Id)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
