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
        private string savedPasswordHash;
        private string custEmail;
        private string custPhoneNumber;
        private string custAddress;


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

        
        public override string ToString() => $"\n\tName:\t\t{this.CustomerName}\n\tEmail:\t\t{this.CustomerEmail}\n\tPhone:\t\t{this.CustomerPhone}\n\tAddress:\t{this.CustomerAddress.ToString()}";
        public bool Equals(Customer value) {
            if (value == null) {
                return false;
            }
            return value.CustomerName == this.CustomerName && value.CustomerEmail == this.CustomerEmail && value.CustomerPhone == this.CustomerPhone;
        }
    }
}