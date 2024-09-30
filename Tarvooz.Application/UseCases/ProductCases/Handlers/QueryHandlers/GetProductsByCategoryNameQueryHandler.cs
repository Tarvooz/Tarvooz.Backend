using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.ProductCases.Queries;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetProductsByCategoryNameQueryHandler : IRequestHandler<GetProductsByCategoryNameQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductsByCategoryNameQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Category category = await _applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Name == request.CategoryName);

                if (category == null)
                {
                    return null;
                }

                category.SearchCount++;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return await _applicationDbContext.Products.Where(p => p.Category.Name == request.CategoryName).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
