using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class CustomerOrderHistory
    {
        public int Id { get; set; }
        public int? LocId { get; set; }
        public int? CustId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public double? Total { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Location Loc { get; set; }
    }
}
