using Application.Features.UserDetailAddresses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Commands.CreateUserDetailAddress
{
    public class CreateUserDetailAddressCommandHandler : IRequestHandler<CreateUserDetailAddressCommandRequest, CreateUserDetailAddressDto>
    {
        private readonly IUserDetailAddressRepository _userDetailAddressRepository;
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public CreateUserDetailAddressCommandHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper, IUserDetailRepository userDetailRepository)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
            _userDetailRepository = userDetailRepository;
        }
        //Request olarak userID alıyoruz bize userDetailId lazım bunu userDetailRepository kullanarak yapabiliriz
        //userId'si requestten gelen userId'ye eşit olan userDetails'ı getirttirdim.

        public async Task<CreateUserDetailAddressDto> Handle(CreateUserDetailAddressCommandRequest request, CancellationToken cancellationToken)
        {
            UserDetail userDetail = await _userDetailRepository.GetAsync(u => u.UserId == Guid.Parse(request.UserId));
            UserDetailAddress userDetailAddress = new() { UserDetailId = userDetail.Id, AddressId = Guid.Parse(request.AddressId) };
            UserDetailAddress mappedUserDetailAddress = await _userDetailAddressRepository.AddAsync(userDetailAddress);
            CreateUserDetailAddressDto createUserDetailAddressDto = _mapper.Map<CreateUserDetailAddressDto>(mappedUserDetailAddress);
            return createUserDetailAddressDto;
        }
    }
}
