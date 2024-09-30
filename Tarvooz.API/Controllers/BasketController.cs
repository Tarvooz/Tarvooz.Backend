using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarvooz.Application.UseCases.BasketCases.Commands;
using Tarvooz.Application.UseCases.BasketCases.Queries;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IEnumerable<Product>> GetUserBaskets(Guid userId)
        {
            return await _mediator.Send(new GetUserBasketsQuery { UserId=userId});
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateBasketCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
