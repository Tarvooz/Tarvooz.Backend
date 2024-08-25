using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.ProductCases.Queries;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllProductsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _applicationDbContext.Products.Skip((request.Page - 1) * request.Count).Take(request.Count).ToListAsync(cancellationToken);
            }   
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
