using System.Collections.Generic;
using System;
namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        //TODO: add more properties to identify the customer
        private string custName;
        //private string userName;
        private string savedPasswordHash;
        private string custEmail;
        private string custPhoneNumber;
        private string custAddress;

        //private Address custBillAddress;
        //private List<Item> custCart;
        //private List<Order> orderHistory;


        public string CustomerName { 
            get { return custName; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("Customer name cannot be empty or null");
                }
                custName = value;
            } 
        }

        public string CustomerEmail { 
            get {
                return custEmail;
            } 
            set {
                if (value.Equals(null)) {
                    //TODO: throw Exception
                }
                custEmail = value;
            }
        
        }

        /*public string UserName {
            get { return userName; }
            set {
                if (value.Equals(null)) {
                    //TODO: thhrow Exception
                }
                userName = value;
            }
        }*/

        public string CustomerPasswordHash {
            get { return savedPasswordHash; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw Exception
                }
                savedPasswordHash = value;
            }
        }

        public string CustomerPhone { 
            get {
                return custPhoneNumber;
            } 
            set {
                if (value.Equals(null)) {
                    //TODO: throw exception
                }
                //format phone number
                custPhoneNumber = value;
            } 
        }

        public string CustomerAddress { 
            get { return custAddress; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw exception
                }
                custAddress = value;
            } 
        }

        public int? Id { get; set; }

        /*public Address CustBillAddress { 
            get { return custBillAddress; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw exception
                }
                custBillAddress = value;
            }
        }

        public List<Item> CustCart { 
            get { return custCart; } 
            set {
                if (value == null) {
                    //todo throw exception
                }
                custCart = value;
            }
        }

        public List<Order> OrderHistory {
            get;
            set;
        }*/
        
        public override string ToString() => $"\n\tName:\t{this.CustomerName}\n\tEmail:\t{this.CustomerEmail}\n\tPhone:\t{this.CustomerPhone}\n\tAddress:\t{this.CustomerAddress.ToString()}";
        public bool Equals(Customer value) {
            if (value == null) {
                return false;
            }
            return value.CustomerName == this.CustomerName && value.CustomerEmail == this.CustomerEmail && value.CustomerPhone == this.CustomerPhone;
        }
    }
}