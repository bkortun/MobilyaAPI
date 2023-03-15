using Application.Features.Addresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Models
{
    public class ListAddressModel:BasePageableModel
    {
        public IList<ListAddressDto> Items { get; set; }
    }
}
