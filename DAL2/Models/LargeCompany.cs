using System;
using System.Collections.Generic;

#nullable disable

namespace DAL2.Models
{
    public partial class LargeCompany
    {
        public int Id { get; set; }
        public int NumberOfEmployees { get; set; }

        public virtual Company IdNavigation { get; set; }
    }
}
