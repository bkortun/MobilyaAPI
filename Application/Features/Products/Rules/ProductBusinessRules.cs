using Application.Features.Products.Commands.DeleteProduct;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;
        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CheckRequestedProductIsNotNull(string productId)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == Guid.Parse(productId));
            if (product == null)
            {
                throw new Exception("Böyle bir ürün mevcut değil!");
            }
            return product;
        }
    }
}

