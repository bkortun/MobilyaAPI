using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Queries.ListProductProductImage
{
    public class ListProductProductImageQueryHandler : IRequestHandler<ListProductProductImageQueryRequest, ListProductProductImageModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ListProductProductImageQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<ListProductProductImageModel> Handle(ListProductProductImageQueryRequest request, CancellationToken cancellationToken)
        {

            IPaginate<ProductImage> productImages = await _productImageRepository.GetListAsync(predicate: p=>p.ProductId==Guid.Parse(request.ProductId),include:m=>m.Include(p=>p.Image).ThenInclude(i=>i.File));
            ListProductProductImageModel getByProductProductImageModel = _mapper.Map<ListProductProductImageModel>(productImages);
            return getByProductProductImageModel;
        }
    }
}
