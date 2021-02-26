using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class CustomerCart
    {
        public int Id { get; set; }
        public int? CustId { get; set; }
        public int? LocId { get; set; }
        public int? CurrentItemsId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Location Loc { get; set; }
    }
}
