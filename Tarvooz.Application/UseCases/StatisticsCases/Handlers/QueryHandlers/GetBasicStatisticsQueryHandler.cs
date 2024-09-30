using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.StatisticsCases.Queries;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.StatisticsCases.Handlers.QueryHandlers
{
    public class GetBasicStatisticsQueryHandler : IRequestHandler<GetBasicStatisticsQuery, IDictionary<string, object>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetBasicStatisticsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IDictionary<string, object>> Handle(GetBasicStatisticsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Dictionary<string, object> statistics=new Dictionary<string, object>();
                List<Basket> baskets=await _applicationDbContext.Baskets.ToListAsync();
                List<Guid> productIds=new List<Guid>();
                
                for(int i = 0; i < baskets.Count; i++)
                {
                    productIds.Add(baskets[i].ProductId);
                }

                List<Product> products = await _applicationDbContext.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

                double avaragePrice = 0;

                for(int i = 0; i < products.Count; i++)
                {
                    avaragePrice += products[i].Price;
                }

                statistics?.Add("avarageMinPrice", avaragePrice / products.Count / 2);
                statistics?.Add("avarageMaxPrice", avaragePrice / products.Count * 2);
                statistics?.Add("searchPattern", await _applicationDbContext.SearchPatterns.OrderByDescending(s => s.SearchCount).Take(10).ToListAsync());
                statistics?.Add("categories", await _applicationDbContext.Categories.OrderByDescending(c => c.SearchCount).Take(5).ToListAsync());

                return statistics;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
