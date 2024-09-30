using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }
        
        [HttpGet]
        [Route("{userId}")]
        public async Task<IEnumerable<Product>> GetUserAllProducts(Guid userId)
        {
            return await _mediator.Send(new GetUserAllProductsQuery { UserId=userId });
        }
        
        [HttpGet]
        [Route("{categoryName}")]
        public async Task<IEnumerable<Product>> GetProductsByCategoryName(string categoryName)
        {
            return await _mediator.Send(new GetProductsByCategoryNameQuery { CategoryName = categoryName });
        }
        
        [HttpGet]
        [Route("{searchPattern}")]
        public async Task<IEnumerable<Product>> GetProductsBySearchPattern(string searchPattern)
        {
            return await _mediator.Send(new GetProductsBySearchPatternQuery { SearchPattern = searchPattern });
        }
        
        [HttpPost]
        public async Task<ResponseModel> Create(CreateProductCommand request)
        {
            return await _mediator.Send(request);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseModel> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteProductByIdCommand { Id = id });
        }
    }
}
