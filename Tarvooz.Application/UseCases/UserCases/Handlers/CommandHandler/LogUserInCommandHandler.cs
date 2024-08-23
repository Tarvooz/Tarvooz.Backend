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
    public class LogUserInCommandHandler : IRequestHandler<LogUserInCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IPasswordService _passwordService;
        private readonly IAuthService _authService;

        public LogUserInCommandHandler(IApplicationDbContext applicationDbContext, IPasswordService passwordService, IAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _passwordService = passwordService;
            _authService = authService;
        }

        public async Task<ResponseModel> Handle(LogUserInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user=await _applicationDbContext.Users.FirstOrDefaultAsync(u=>u.Email == request.Email);

                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Email is not found!"
                    };
                }

                bool isPasswordCorrect = _passwordService.CheckPassword(request.Password, new PasswordModel
                {
                    PasswordHash = user.PasswordHash,
                    PasswordSalt = user.PasswordSalt,
                });

                if (isPasswordCorrect==false)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "Password is incorrect!"
                    };
                }

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = _authService.GenerateToken(user)
                };
            }
            catch(Exception ex)
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
