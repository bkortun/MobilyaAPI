using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Dtos
{
    public class UpdateUserDetailDto
    {
        public string Id { get; set; }
        //public string Name { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePhotoId { get; set; }
        public bool Gender { get; set; }
    }
}
