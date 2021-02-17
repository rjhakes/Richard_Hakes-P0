using System;
using StoreModels;
using StoreBL;


namespace StoreUI
{
    class Program
    {
        /// <summary>
        /// This is the main method, its the starting point of your application
        /// </summary>
        /// <param name="args"></param>

        private static ICustomerBL customerBL = new CustomerBL();

        static void Main(string[] args)
        {
            //call method that starts main user interface
            Customer newCustomer = new Customer();
            Console.WriteLine("Enter Customer Name: ");
            newCustomer.CustName = Console.ReadLine();
            Console.WriteLine("Enter Customer Email (example@domain.com)");
            newCustomer.CustEmail = Console.ReadLine();
            Console.WriteLine("Enter Customer Phone # (1234567890):");
            newCustomer.CustPhoneNumber = Console.ReadLine(); 
            Console.WriteLine("Enter Customer's Shipping Address");
            Address newAddress = new Address();
            Console.WriteLine("Street:");
            newAddress.Street = Console.ReadLine();
            Console.WriteLine("City:");
            newAddress.City = Console.ReadLine();
            Console.WriteLine("State:");
            newAddress.State = Console.ReadLine();
            Console.WriteLine("Country:");
            newAddress.Country = Console.ReadLine();
            Console.WriteLine("Postal Code:");
            newAddress.PostalCode = Console.ReadLine();
            newCustomer.CustShipAddress = newAddress;
            Console.WriteLine("Is the Customer's Billing Address the same as Shipping? (y/n):");
            if (Console.ReadLine()[0] == 'y') {
                newCustomer.CustBillAddress = newCustomer.CustShipAddress;
            } else {
                newAddress = new Address();
                Console.WriteLine("Street:");
                newAddress.Street = Console.ReadLine();
                Console.WriteLine("City:");
                newAddress.City = Console.ReadLine();
                Console.WriteLine("State:");
                newAddress.State = Console.ReadLine();
                Console.WriteLine("Country:");
                newAddress.Country = Console.ReadLine();
                Console.WriteLine("Postal Code:");
                newAddress.PostalCode = Console.ReadLine();
                newCustomer.CustBillAddress = newAddress;
            }
            customerBL.AddCustomer(newCustomer);
            foreach (var item in customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
