using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : Entity
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string District { get; set; }//ilçe
        public string Neighbourhood { get; set; }//mahalle
        public string AddressDetail { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public virtual ICollection<UserDetailAddress> UserDetailAddresses { get; set; }
    }
}
