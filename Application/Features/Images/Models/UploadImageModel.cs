using Application.Features.Images.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Models
{
    public class UploadImageModel:BasePageableModel
    {
        public List<UploadImageDto> Items { get; set; }
    }
}
