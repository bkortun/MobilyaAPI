using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using Infrastructure.Storage.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Queries.ListProductProductImage
{
    public class ListProductImageQueryHandler : IRequestHandler<ListProductImageQueryRequest, ListProductImageModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public ListProductImageQueryHandler(IProductImageRepository productImageRepository, IMapper mapper, IStorageService storageService)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ListProductImageModel> Handle(ListProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProductImage> productImages = await _productImageRepository
                .GetListAsync(predicate: p=>p.ProductId==Guid.Parse(request.ProductId)
                ,include:m=>m.Include(p=>p.Image).ThenInclude(i=>i.File).Include(p=>p.Product));
            ListProductImageModel getByProductProductImageModel = _mapper.Map<ListProductImageModel>(productImages);
            return getByProductProductImageModel;
        }
    }
}
