using Application.Domain.Commands.ProductsCommands;
using Application.Domain.Models;
using Application.IRepository;
using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Handlers.ProductsHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Products>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<Products>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updateProduct = _mapper.Map<Products>(request);
            return await _productRepository.Update(updateProduct);
        }
    }
}
