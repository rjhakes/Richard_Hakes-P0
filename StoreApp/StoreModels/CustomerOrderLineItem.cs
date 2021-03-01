using System.Collections.Generic;
using System;
namespace StoreModels
{
    public class CustomerOrderLineItem
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProdId { get; set; }
        public int? Quantity { get; set; }
        public double? ProdPrice { get; set; }

        public override string ToString() => $"\n\tOrder ID:\t\t{this.OrderId}\n\tQuantity:\t\t{this.Quantity}\n";
    }
}