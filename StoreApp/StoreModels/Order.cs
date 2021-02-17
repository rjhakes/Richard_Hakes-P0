using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        private Customer customer;
        private Location location;
        private List<Item> cart;
        private double total;

        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public List<Item> Cart { get; set; }
        public double Total { get; set; }

        //TODO: add a property for the order items
    }
}