using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Dtos
{
    public class ListProfilePhotoDto
    {
        public string UserId { get; set; }
        public string ImageId { get; set; }
        public string FileId { get; set; }
        public string ImageName { get; set; }
        public string Path { get; set; }
    }
}
