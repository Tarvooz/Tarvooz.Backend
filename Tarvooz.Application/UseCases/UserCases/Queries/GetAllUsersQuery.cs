using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.UserCases.Queries
{
    public class GetAllUsersQuery:IRequest<IEnumerable<User>>
    {
    }
}
