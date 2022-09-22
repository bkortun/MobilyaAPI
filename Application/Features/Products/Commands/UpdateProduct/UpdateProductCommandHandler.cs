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

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductDto> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo Şuanki sistemde update işlemi yapılacak iken tüm proplar requestten alınmalı, nullable özelliği yapılıcak
            Product product = _mapper.Map<Product>(request);
            Product updatedProduct = await _productRepository.UpdateAsync(product);
            UpdateProductDto updateProductDto = _mapper.Map<UpdateProductDto>(updatedProduct);
            return updateProductDto;
        }
    }
}
