using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        private string address;
        private string locationName;
        private List<Item> inventory;

        public string Address { get; set; }
        public string LocationName { get; set; }
        public List<Item> Inventory { get; set; }
        //TODO: add some property for the location inventory
    }
}