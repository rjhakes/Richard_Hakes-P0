using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            CustomerOrderLineItems = new HashSet<CustomerOrderLineItem>();
            InventoryLineItems = new HashSet<InventoryLineItem>();
            StoreOrderLineItems = new HashSet<StoreOrderLineItem>();
        }

        public int Id { get; set; }
        public string ProdName { get; set; }
        public double ProdPrice { get; set; }
        public int? ProdCategory { get; set; }
        public string ProdBrandName { get; set; }

        public virtual Category ProdCategoryNavigation { get; set; }
        public virtual ICollection<CustomerOrderLineItem> CustomerOrderLineItems { get; set; }
        public virtual ICollection<InventoryLineItem> InventoryLineItems { get; set; }
        public virtual ICollection<StoreOrderLineItem> StoreOrderLineItems { get; set; }
    }
}
