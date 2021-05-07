using System;
using System.Collections.Generic;

#nullable disable

namespace DAL2.Models
{
    public partial class Address
    {
        public Address()
        {
            AddressCompanies = new HashSet<AddressCompany>();
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<AddressCompany> AddressCompanies { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
