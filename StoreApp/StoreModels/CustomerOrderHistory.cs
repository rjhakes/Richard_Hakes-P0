using System.Collections.Generic;
using System;
namespace StoreModels
{
    public class CustomerOrderHistory
    {
        public int? Id { get; set; }
        public int? LocId { get; set; }
        public int? CustId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? OrderId { get; set; }
        public double? Total { get; set; }

        public override string ToString() => $"Order ID: {this.OrderId}\t\tDate: {this.OrderDate.ToString("yyyy-MM-dd")}\t\tTotal: ${this.Total}";
    }
}