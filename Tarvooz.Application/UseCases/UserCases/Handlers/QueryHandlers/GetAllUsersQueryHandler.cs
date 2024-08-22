using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.UserCases.Queries;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.UserCases.Handlers.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllUsersQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _applicationDbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
