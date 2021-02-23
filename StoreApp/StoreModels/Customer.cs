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
        private string userName;
        private string savedPasswordHash;
        private string custEmail;
        private string custPhoneNumber;
        private Address custShipAddress;
        private Address custBillAddress;
        private List<Item> custCart;
        private List<Order> orderHistory;


        public string CustName { 
            get { return custName; } 
            set {
                if (value == null || value.Equals("")) {
                    throw new ArgumentNullException("Customer name cannot be empty or null");
                }
                custName = value;
            } 
        }

        public string CustEmail { 
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

        public string UserName {
            get { return userName; }
            set {
                if (value.Equals(null)) {
                    //TODO: thhrow Exception
                }
                userName = value;
            }
        }

        public string SavedPasswordHash {
            get { return savedPasswordHash; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw Exception
                }
                savedPasswordHash = value;
            }
        }

        public string CustPhoneNumber { 
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

        public Address CustShipAddress { 
            get { return custShipAddress; }
            set {
                if (value.Equals(null)) {
                    //TODO: throw exception
                }
                custShipAddress = value;
            } 
        }

        public Address CustBillAddress { 
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
        }
        
        public override string ToString() => $"Customer Details: \n\t Name:\t\t{this.CustName} \n\t User Name:\t{this.UserName} \n\t Email:\t\t{this.CustEmail} \n\t Phone:\t\t{this.CustPhoneNumber} \n\t Address-- {this.CustShipAddress.ToString()}";
        public bool Equals(Customer value) {
            if (value == null) {
                return false;
            }
            return value.CustName == this.CustName && value.UserName == this.UserName && value.CustEmail == this.CustEmail && value.CustPhoneNumber == this.CustPhoneNumber;
        }
    }
}