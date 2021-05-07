using System;
using System.Collections.Generic;

#nullable disable

namespace DAL2.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public decimal Pesel { get; set; }
        public string FullName { get; set; }
        public int? AddressId { get; set; }
        public int? IndexNumber { get; set; }
        public string Specialization { get; set; }
        public int ClassType { get; set; }
        public string SchoolName { get; set; }

        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
    }
}
