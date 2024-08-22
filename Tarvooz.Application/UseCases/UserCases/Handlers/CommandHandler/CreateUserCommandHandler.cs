using Mapster;
using MediatR;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.UserCases.Commands;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = request.Adapt<User>();
                await _applicationDbContext.Users.AddAsync(user);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "User successfully created!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = $"Something went wrong!: {ex}"
                };
            }
        }
    }
}
