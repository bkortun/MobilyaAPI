using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
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
        private readonly ProductBusinessRules _businessRules;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules businessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdateProductDto> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo Şuanki sistemde update işlemi yapılacak iken tüm proplar requestten alınmalı, nullable özelliği yapılıcak.
            Product checkedProduct = await _businessRules.CheckRequestedIsNotNull(request.Id);
            Product product = _mapper.Map<Product>(checkedProduct);
            Product updatedProduct = await _productRepository.UpdateAsync(product);
            UpdateProductDto updateProductDto = _mapper.Map<UpdateProductDto>(updatedProduct);
            return updateProductDto;
        }
    }
}
