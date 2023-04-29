using Application.Domain.Models;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Queries.ProductsQueries
{
    public class GetAllProducts : IRequest<Result<List<Products>>>
    {
    }
}
