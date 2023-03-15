using Application.Features.UserDetails.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Models
{
    public class ListUserDetailModel : BasePageableModel
    {
        public IList<ListUserDetailDto> Items { get; set; }
    }
}
