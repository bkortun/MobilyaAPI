using Application.Features.UserDetails.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Queries.ListByIdUserDetail
{
    public class ListByIdUserDetailQueryHandle : IRequestHandler<ListByIdUserDetailQueryRequest, ListByIdUserDetailDto>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ListByIdUserDetailQueryHandle(IUserDetailRepository userDetailRepository, IMapper mapper, IUserRepository userRepository)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ListByIdUserDetailDto> Handle(ListByIdUserDetailQueryRequest request, CancellationToken cancellationToken)
        {
            //Todo burada getAsync fonksyonu include özelliğine sahip olmadığı için user ve userDetail tablolarını ayrı ayrı çektim
            //bu iki objeyi maplemek zor oluduğu için amele yöntemi ile aşağıda doldurdum, Burası refactor edilip düzgün bir sisteme oturtulmalı
            //bu iş sende hocam
            UserDetail userDetail = await _userDetailRepository.GetAsync(p => p.User.Id == Guid.Parse(request.UserId));
            User user = await _userRepository.GetAsync(p => p.Id == Guid.Parse(request.UserId));
            ListByIdUserDetailDto detailDto = new()
            {
                Id = userDetail.Id.ToString(),
                Email = user.Email,
                UserId=user.Id.ToString(),
                FirstName=user.FirstName,
                LastName=user.LastName,
                PhoneNumber=userDetail.PhoneNumber,
//ProfilePhotoId=userDetail.ProfilePhotoId.ToString(),
                CreatedDate=userDetail.CreatedDate,
                UpdatedDate=userDetail.UpdatedDate,
                Status=userDetail.Status,
            };
            return detailDto;
        }
    }
}
