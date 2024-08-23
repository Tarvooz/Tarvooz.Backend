using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.Services.AuthServices;
using Tarvooz.Application.Services.PasswordServices;
using Tarvooz.Application.UseCases.UserCases.Commands;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IPasswordService _passwordService;
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IApplicationDbContext applicationDbContext, IPasswordService passwordService, IAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _passwordService = passwordService;
            _authService = authService;
        }

        public async Task<ResponseModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Verification verification = await _applicationDbContext.Verifications.FirstOrDefaultAsync(v => v.Email == request.Email && v.SentPassword == request.SentPassword);

                if (verification == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Sent password is incorrect"
                    };
                }

                User user = request.Adapt<User>();

                PasswordModel passwordModel = _passwordService.HashPassword(request.Password);

                user.PasswordHash = passwordModel.PasswordHash;
                user.PasswordSalt = passwordModel.PasswordSalt;

                await _applicationDbContext.Users.AddAsync(user);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = _authService.GenerateToken(user)
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
