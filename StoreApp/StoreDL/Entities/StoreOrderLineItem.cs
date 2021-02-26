using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreOrderLineItem
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProdId { get; set; }
        public int? Quantity { get; set; }
        public double? ProdPrice { get; set; }

        public virtual Product Prod { get; set; }
    }
}
