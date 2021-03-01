using System.Collections.Generic;
using System;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class InventoryLineItem
    {
        //TODO: add more properties to identify the customer

        public int? Id { get; set; }
        public int? InventoryId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }

        public override string ToString() => $"\tProduct ID:\t\t{this.ProductId}\n\tQuantity:\t\t{this.Quantity}\n";
    }
}