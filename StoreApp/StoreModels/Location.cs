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

        public Address Address { 
            get {return address;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                address = value;
            }
        }
        public string LocationName { 
            get {return locationName;} 
            set {
                if (value == null) {
                    //todo:throw exception
                }
                locationName = value;
            }
        }
        public List<Item> Inventory { 
            get {return inventory;}
            set {
                if (value == null) {
                    //todo throw exception 
                }
                inventory = value;
            }
        }
        public List<Order> OrderHistory { 
            get {return orderHistory;}
            set {
                if (value == null) {
                    //todo throw exception
                }
                orderHistory = OrderHistory;
            }
            }

        //TODO: add some property for the location inventory

        public override string ToString() => $"\t Location Name: \t{this.LocationName} \n\t Address-- {this.Address.ToString()}\n";
    }
}