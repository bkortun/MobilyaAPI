﻿using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,CreateProductCommandRequest>().ReverseMap();

            CreateMap<Product, ListProductDto>().ReverseMap();
            CreateMap<IPaginate<Product>, ListProductModel>().ReverseMap();

            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Product, DeleteProductCommandRequest>().ReverseMap();
            CreateMap<Product, DeleteProductDto>().ReverseMap();

            CreateMap<Product, ListByIdProductDto>().ReverseMap();
        }
    }
}
