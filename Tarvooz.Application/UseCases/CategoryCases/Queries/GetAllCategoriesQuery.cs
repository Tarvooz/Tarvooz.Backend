using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.CategoryCases.Queries
{
    public class GetAllCategoriesQuery:IRequest<IEnumerable<Category>>
    {
    }
}
