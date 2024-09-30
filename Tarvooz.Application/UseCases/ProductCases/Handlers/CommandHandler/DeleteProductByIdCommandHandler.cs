using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.ProductCases.Commands;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Handlers.CommandHandler
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteProductByIdCommandHandler(IApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id);

                if (product == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Product not found to delete!"
                    };
                }

                _applicationDbContext.Products.Remove(product);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "Product is successfuly deleted!"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = "Something went wrong!"
                };
            }
        }
    }
}
