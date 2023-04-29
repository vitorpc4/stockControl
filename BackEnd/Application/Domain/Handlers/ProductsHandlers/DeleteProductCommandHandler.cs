using Application.Domain.Commands.ProductsCommands;
using Application.Domain.Models;
using Application.IRepository;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Handlers.ProductsHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<Products>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Products>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.Delete(request.Id);
        }
    }
}
