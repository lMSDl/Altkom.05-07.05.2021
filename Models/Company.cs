﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Company : Entity
    {
        public IEnumerable<Address> Addresses { get; set; }

        public int OwnerId { get; set; }
        public Person Owner { get; set; }
    }
}
