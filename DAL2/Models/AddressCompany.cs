using System;
using System.Collections.Generic;

#nullable disable

namespace DAL2.Models
{
    public partial class AddressCompany
    {
        public int AddressesId { get; set; }
        public int CompaniesId { get; set; }

        public virtual Address Addresses { get; set; }
        public virtual Company Companies { get; set; }
    }
}
