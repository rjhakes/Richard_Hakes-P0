

namespace StoreModels
{
    public class Address
    {
        /*private string street;
        private string city;
        private string country;
        private string postalCode;*/

        public string Street { get; set; }
        public string City { get; set; }   
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public override string ToString() => $"\n\t\t Street:\t {this.Street} \n\t\t City:\t\t {this.City} \n\t\t State:\t\t {this.State} \n\t\t Country:\t {this.Country} \n\t\t Postal Code:\t {this.PostalCode} \n\t";
    }
}