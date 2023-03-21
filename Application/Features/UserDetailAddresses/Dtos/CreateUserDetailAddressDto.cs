using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Dtos
{
    public class CreateUserDetailAddressDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string AddressId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }

    }
}
