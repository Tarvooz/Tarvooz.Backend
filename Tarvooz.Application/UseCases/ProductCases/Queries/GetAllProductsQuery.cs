﻿using MediatR;
using Tarvooz.Domain.Entities.Models;

namespace Tarvooz.Application.UseCases.ProductCases.Queries
{
    public class GetAllProductsQuery:IRequest<IEnumerable<Product>>
    {
    }
}
