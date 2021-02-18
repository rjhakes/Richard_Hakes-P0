using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        private Address address;
        private string locationName;
        private List<Item> inventory;
        private List<Order> orderHistory;

        public Address Address { get; set; }
        public string LocationName { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Order> OrderHistory { get; set; }
        //TODO: add some property for the location inventory

        public override string ToString() => $"\n\t {this.LocationName} \n";
    }
}