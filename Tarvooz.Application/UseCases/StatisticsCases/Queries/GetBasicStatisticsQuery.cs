using MediatR;

namespace Tarvooz.Application.UseCases.StatisticsCases.Queries
{
    public class GetBasicStatisticsQuery:IRequest<IDictionary<string,object>>
    {
    }
}
