using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.StatisticsCases.Queries;

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
