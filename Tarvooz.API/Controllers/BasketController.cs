using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarvooz.Application.UseCases.BasketCases.Commands;
using Tarvooz.Domain.Entities.DTOs;

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

        [HttpPost]
        public async Task<ResponseModel> Create(CreateBasketCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
