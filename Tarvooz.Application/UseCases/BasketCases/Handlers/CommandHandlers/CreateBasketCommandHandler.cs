using MediatR;
using Microsoft.EntityFrameworkCore;
using Tarvooz.Application.Abstractions;
using Tarvooz.Application.UseCases.BasketCases.Commands;
using Tarvooz.Domain.Entities.DTOs;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.BasketCases.Handlers.CommandHandlers
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, ResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateBasketCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResponseModel> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
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
                        Response = "User not found!"
                    };
                }

                Product product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == request.ProductId);

                if (product == null)
                {
                    return new ResponseModel
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "Product not found!"
                    };
                }

                await _applicationDbContext.Baskets.AddAsync(new Basket
                {
                    User = user,
                    Product = product
                });

                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "Mahsulot savatchaga qo'shildi!"
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
