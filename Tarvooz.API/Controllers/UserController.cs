using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tarvooz.Application.UseCases.UserCases.Commands;
using Tarvooz.Application.UseCases.UserCases.Queries;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        public async Task<ResponseModel> SendVerification(SendVerificationToUserCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ResponseModel> Register(RegisterUserCommand request)
        {
            return await _mediator.Send(request);
        }
        
        [HttpPost]
        public async Task<ResponseModel> LogIn(LogUserInCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
