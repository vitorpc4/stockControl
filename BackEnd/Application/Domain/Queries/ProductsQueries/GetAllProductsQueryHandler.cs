using Application.Domain.Models;
using Application.IRepository;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Queries.ProductsQueries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProducts, Result<List<Products>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<Products>>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {

            return await _productRepository.GetAll();

        }
    }
}
