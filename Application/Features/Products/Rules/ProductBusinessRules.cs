using Application.Features.Products.Commands.DeleteProduct;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.BusinessRules;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules:BaseBusinessRules<IProductRepository,Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductBusinessRules(IProductRepository productRepository):base(productRepository) 
        {
            _productRepository = productRepository;
        }

        
    }
}

