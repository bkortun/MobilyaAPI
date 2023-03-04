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

namespace Application.Features.ProductImages.Queries.ListByShowcaseImage
{
    public class ListByShowcaseProductImageQueryHandler : IRequestHandler<ListByShowcaseProductImageQueryRequest, ListByShowcaseProductImageModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public ListByShowcaseProductImageQueryHandler(IProductImageRepository productImageRepository, IMapper mapper, IStorageService storageService)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _storageService = storageService;
        }

        public async Task<ListByShowcaseProductImageModel> Handle(ListByShowcaseProductImageQueryRequest request, CancellationToken cancellationToken)
        {
           var imageCount= _storageService.GetFilesName("wwwroot/product-images").Count;
            IPaginate<ProductImage> productImages = await _productImageRepository.GetListAsync(predicate: p => p.Image.Showcase == true,
                index:0,size:imageCount, include: m => m.Include(p => p.Image).ThenInclude(i => i.File).Include(p => p.Product));
            ListByShowcaseProductImageModel listByShowcaseProductImageModel = _mapper.Map<ListByShowcaseProductImageModel>(productImages);
            return listByShowcaseProductImageModel;
        }
    }
}
