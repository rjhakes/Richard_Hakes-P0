using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryLineItems = new HashSet<InventoryLineItem>();
        }

        public int Id { get; set; }
        public int LocId { get; set; }

        public virtual Location Loc { get; set; }
        public virtual ICollection<InventoryLineItem> InventoryLineItems { get; set; }
    }
}
