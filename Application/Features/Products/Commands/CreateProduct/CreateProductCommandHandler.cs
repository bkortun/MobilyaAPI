using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreatedProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreatedProductDto> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product= _mapper.Map<Product>(request);
            bool success=await _productRepository.AddAsync(product);
            if (success) await _productRepository.SaveAsync();
            CreatedProductDto createdProductDto=_mapper.Map<CreatedProductDto>(product);
            return createdProductDto;
        }
    }
}
