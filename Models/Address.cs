﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[NotMapped]
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public IEnumerable<Person> People { get; set; }
        public IEnumerable<Company> Companies { get; set; }
    }
}
