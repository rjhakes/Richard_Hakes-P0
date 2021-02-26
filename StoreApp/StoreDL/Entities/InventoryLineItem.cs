﻿using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class InventoryLineItem
    {
        public int Id { get; set; }
        public int? InventoryId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
    }
}
