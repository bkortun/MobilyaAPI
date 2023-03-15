using Application.Features.UserDetailAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Models
{
    public class ListUserDetailAddressModel:BasePageableModel
    {
        public IList<ListUserDetailAddressDto> Items { get; set; }
    }
}
