using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Tarvooz.Application.UseCases.CategoryCases.Commands;
using Tarvooz.Application.UseCases.CategoryCases.Queries;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetALl()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }
        
        [HttpPost]
        public async Task<ResponseModel> Create(CreateCategoryCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
