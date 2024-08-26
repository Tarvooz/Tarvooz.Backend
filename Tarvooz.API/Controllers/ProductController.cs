using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarvooz.Application.UseCases.CategoryCases.Queries;
using Tarvooz.Application.UseCases.ProductCases.Commands;
using Tarvooz.Application.UseCases.ProductCases.Queries;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetALl()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }
        
        [HttpPost]
        public async Task<ResponseModel> Create(CreateProductCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
