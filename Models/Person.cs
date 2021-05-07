using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    //[Table("People", Schema = "efc")]
    //[Microsoft.EntityFrameworkCore.Index(nameof(BirthDate), IsUnique = true, Name = "Index_BirthDate")]
    public class Person : Entity, IModifiedDate
    {
        //public int Identifier { get; set; }

        public decimal PESEL { get; set; }
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        //[MaxLength(24)]
        public string LastName { get; set; }
        //public Nullable<DateTime> BirthDate { get; set; }
        public DateTime? BirthDate { get; set; }

        //[NotMapped]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public decimal SomeData { get; set; }

        public DateTime Modified { get; set; }

        public string FullName { get; set; }

        public Company Company {get; set;}

        public int ClassType { get; set; }
    }
}
