using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.ProductCases.Queries;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetUserAllProductsQuesryHandler : IRequestHandler<GetUserAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetUserAllProductsQuesryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetUserAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _applicationDbContext.Products.Where(p => p.User.Id == request.UserId).ToListAsync();
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
