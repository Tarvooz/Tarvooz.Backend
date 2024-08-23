using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.Services.EmailServices
{
    public interface ISendEmailService
    {
        public Task<ResponseModel> SendEmailAsync(EmailDTO emailDTO);
    }
}
