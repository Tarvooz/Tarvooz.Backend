using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.Services.EmailServices;
using Tarvooz.Application.UseCases.UserCases.Commands;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.UserCases.Handlers.CommandHandler
{
    public class SendVerificationToUserCommandHandler : IRequestHandler<SendVerificationToUserCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ISendEmailService _sendEmailService;

        public SendVerificationToUserCommandHandler(IApplicationDbContext applicationDbContext, ISendEmailService sendEmailService)
        {
            _applicationDbContext = applicationDbContext;
            _sendEmailService = sendEmailService;
        }

        public async Task<ResponseModel> Handle(SendVerificationToUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user=await _applicationDbContext.Users.FirstOrDefaultAsync(u=>u.Email==request.Email);

                if (user!=null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Response = "User already exists!"
                    };
                }

                Verification verification=await _applicationDbContext.Verifications.FirstOrDefaultAsync(v=>v.Email==request.Email);

                verification = request.Adapt<Verification>();

                Random random=new Random();

                verification.SentPassword = random.Next(100000, 999999).ToString();

                _applicationDbContext.Verifications.Update(verification);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                ResponseModel response= await _sendEmailService.SendEmailAsync(new EmailDTO
                {
                    To = request.Email,
                    Subject = "Verify your Email",
                    Body = verification.SentPassword,
                    IsBodyHTML = false
                });

                return response;
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
