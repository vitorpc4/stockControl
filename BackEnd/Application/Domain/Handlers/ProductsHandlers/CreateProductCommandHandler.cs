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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Products>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<Products>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Products>(request);
            return await _productRepository.Add(product);

        }
    }
}
