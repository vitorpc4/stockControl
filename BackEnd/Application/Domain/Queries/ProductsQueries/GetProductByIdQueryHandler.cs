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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductById, Result<Products>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Products>> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(request.Id);
        }
    }
}
