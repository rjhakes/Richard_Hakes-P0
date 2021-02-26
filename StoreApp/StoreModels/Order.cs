using System.Collections.Generic;
using System;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order. 
    /// </summary>
    public class Order
    {
        private string date;
        private Customer customer;
        private string locationName;
        private Address locationAddress;
        private List<Item> cart;
        private double total;


        public string Date {
            get { return date; }
            set { 
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("");
                }
                date = value;
            }
        }
        public Customer Customer { 
            get { return customer; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("Customer name cannot be empty or null");
                }
                customer = value;
            } 
        }
        public string LocationName {
            get { return locationName; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("");
                }
                locationName = value;
            } 
        }

        public Address LocationAddress {
            get { return locationAddress; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("");
                }
                locationAddress = value;
            } 
        }

        public List<Item> Cart { 
            get { return cart; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("");
                }
                cart = value;
            } 
        }
        public double Total {
            get { return total; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("");
                }
                total = value;
            } 
        }

        public override string ToString() => $"\n\tDate:\t\t\t{this.Date}\n\tLocation Name\t\t{this.LocationName}\n\tLocation Address--\t{this.LocationAddress}"; //\n\tCart:\t{this.Cart}\n\tTotal:\t{this.Total}";
    }
}