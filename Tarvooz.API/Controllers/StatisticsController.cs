using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarvooz.Application.UseCases.StatisticsCases.Queries;

namespace Tarvooz.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IDictionary<string,object>> GetBasicStatistics()
        {
            return await _mediator.Send(new GetBasicStatisticsQuery());
        }
    }
}
