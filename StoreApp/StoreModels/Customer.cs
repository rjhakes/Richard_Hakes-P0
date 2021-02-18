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
        private string custEmail;
        private string custPhoneNumber;
        private Address custShipAddress;
        private Address custBillAddress;
        private List<Item> custCart;
        //Order History


        public string CustName { 
            get { return custName; } 
            set {
                if (value.Equals(null) || value.Equals("")) {
                    throw new ArgumentNullException("Customer cannot be empty or null");
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
            get; 
            set; 
        }
        
        public override string ToString() => $"Customer Details: \n\t Name: {this.CustName} \n\t Email: {this.CustEmail} \n\t Phone: {this.CustPhoneNumber} \n\t Address-- {this.CustShipAddress.ToString()}";
    }
}