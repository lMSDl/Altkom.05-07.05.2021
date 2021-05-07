using System;
using System.Collections.Generic;

#nullable disable

namespace DAL2.Models
{
    public partial class Company
    {
        public Company()
        {
            AddressCompanies = new HashSet<AddressCompany>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }

        public virtual Person Owner { get; set; }
        public virtual LargeCompany LargeCompany { get; set; }
        public virtual SmallCompany SmallCompany { get; set; }
        public virtual ICollection<AddressCompany> AddressCompanies { get; set; }
    }
}
