using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.ProductCases.Queries;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetProductsBySearchPatternQueryHandler : IRequestHandler<GetProductsBySearchPatternQuery, IEnumerable<Product>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetProductsBySearchPatternQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsBySearchPatternQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Category category= await _applicationDbContext.Categories.FirstOrDefaultAsync(p=>p.Name.ToUpper()==request.SearchPattern.ToUpper());
                SearchPattern searchPattern= await _applicationDbContext.SearchPatterns.FirstOrDefaultAsync(s=>s.SearchWord.ToUpper()==request.SearchPattern.ToUpper());

                if (category!=null)
                {
                    category.SearchCount++;
                }


                if(searchPattern==null)
                {
                    searchPattern=new SearchPattern();
                    searchPattern.SearchCount=1;
                    searchPattern.SearchWord=request.SearchPattern;
                    
                    await _applicationDbContext.SearchPatterns.AddAsync(searchPattern);
                }
                else
                {
                    searchPattern.SearchCount++;
                }

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                List<Product> products=new List<Product>();

                products?.AddRange(await _applicationDbContext.Products.Where(p => EF.Functions.Like(p.Name.ToUpper(), $"%{request.SearchPattern.ToUpper().Trim()}%")).ToListAsync());
                products?.AddRange(await _applicationDbContext.Products.Where(p => EF.Functions.Like(p.Description.ToUpper(), $"%{request.SearchPattern.ToUpper().Trim()}%")).ToListAsync());
                products?.AddRange(await _applicationDbContext.Products.Where(p => p.Category.Name.ToUpper().Contains(request.SearchPattern.ToUpper().Trim())).ToListAsync());

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
