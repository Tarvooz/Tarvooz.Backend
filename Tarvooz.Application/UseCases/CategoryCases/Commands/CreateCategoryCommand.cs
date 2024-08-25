using MediatR;
using Tarvooz.Domain.Entities.DTOs;

namespace Tarvooz.Application.UseCases.CategoryCases.Commands
{
    public class CreateCategoryCommand:IRequest<ResponseModel>
    {
        public string Name { get; set; }
    }
}
