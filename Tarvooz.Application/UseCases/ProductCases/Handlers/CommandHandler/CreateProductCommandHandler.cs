using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.ProductCases.Commands;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;
using Microsoft.AspNetCore.Hosting;

namespace Tarvooz.Application.UseCases.ProductCases.Handlers.CommandHandler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProductCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId);

                if (user == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Use is not found"
                    };
                }

                Category category = await _applicationDbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);

                if (category == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Category is not found!"
                    };
                }

                string path = Path.Combine("\\productImages", $"{Guid.NewGuid()}-{request.Image.FileName}");
                using (FileStream strem = new FileStream(_webHostEnvironment.WebRootPath+path, FileMode.Create))
                    request.Image.CopyTo(strem);

                Product product = request.Adapt<Product>();

                product.User=user;
                product.Category=category;
                product.ImagePath=path;
                product.CreatedDate= DateTime.UtcNow;

                await _applicationDbContext.Products.AddAsync(product);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "Product successfully created!"
                };
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
