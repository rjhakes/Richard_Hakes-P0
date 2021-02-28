using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        private string locAddress;
        private string locName;
        private string locPhone;
        // private List<Item> inventory;
        // private List<Order> orderHistory;

        public int? Id { get; set; }

        public string LocAddress { 
            get {return locAddress;}
            set {
                if (value == null) {
                    //todo: throw exception
                }
                locAddress = value;
            }
        }
        public string LocName { 
            get {return locName;} 
            set {
                if (value == null) {
                    //todo:throw exception
                }
                locName = value;
            }
        }
        public string LocPhone { 
            get {return locPhone;} 
            set {
                if (value == null) {
                    //todo:throw exception
                }
                locPhone = value;
            }
        }
        /*public List<Item> Inventory { 
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
        }*/

        //TODO: add some property for the location inventory

        public override string ToString() => $"\tLocation Name:\t{this.LocName}\n\tLocation Phone:\t{this.LocPhone}\n\tAddress:\t{this.LocAddress.ToString()}\n";
    }
}