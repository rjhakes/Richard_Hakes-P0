using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class VCustomerOrderHistory
    {
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public string CustomerEmail { get; set; }
        public string LocName { get; set; }
        public string ProdName { get; set; }
        public int? Quantity { get; set; }
        public double? ProdPrice { get; set; }
        public double? ItemizedTotal { get; set; }
        public double? CartTotal { get; set; }
    }
}
