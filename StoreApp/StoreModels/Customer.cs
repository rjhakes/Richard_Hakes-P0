using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain necessary properties and fields for customer info.
    /// </summary>
    public class Customer
    {
        private string custName;
        private string custEmail;
        private int custPhoneNumber;
        private Address custShipAddress;
        private Address custBillAddress;
        private List<Item> custCart;


        public string CustName { 
            get { return custName; } 
            set {
                if (value.Equals(null)) {
                    //TODO: throw exception
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

        public int CustPhoneNumber { 
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

        public string CustShipAddress { get; set; }
        public string CustBillAddress { get; set; }
        public List<Item> CustCart { get; set; }
        //TODO: add more properties to identify the customer
    }
}