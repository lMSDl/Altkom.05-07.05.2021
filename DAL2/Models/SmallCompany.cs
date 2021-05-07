using System;
using System.Collections.Generic;

#nullable disable

namespace DAL2.Models
{
    public partial class SmallCompany
    {
        public int Id { get; set; }

        public virtual Company IdNavigation { get; set; }
    }
}
