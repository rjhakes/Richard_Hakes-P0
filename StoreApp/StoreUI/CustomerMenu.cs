using System;
using StoreModels;
using StoreBL;
using StoreDL;

namespace StoreUI
{
    public class CustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        public CustomerMenu(ICustomerBL customerBL) {
            _customerBL = customerBL;
        }
        public void Start() {
            Boolean stay = true;
            do
            {
                //menu options part
                Console.WriteLine("Welcome to my Store app! What would you like to do?");
                Console.WriteLine("[0] Register as Customer");
                Console.WriteLine("[1] Shop");
                Console.WriteLine("[2] Review my Account Information");
                Console.WriteLine("[3] View my Order History");
                Console.WriteLine("[4] View my Cart");
                Console.WriteLine("[5] Complete my Purchase");
                Console.WriteLine("[6] Exit.");
                Console.WriteLine("\n\n[7] Store Manager Login");

                //get user input
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        try {
                            CreateCustomer();
                        } catch (Exception e) {
                            Console.WriteLine("Invalid Input" + e.Message);
                            continue;
                        }
                        break;
                    case "1":
                        //IMenu menu = new ShopMenu();
                        //string storeLocation = menu.Start();
                        IMenu menu = new LocationMenu(new LocationBL(new LocationRepoFile()));
                        menu.Start();
                        break;
                    case "2":
                        GetCustomers();
                        break;
                    case "3":
                        GetOrderHistory();
                        break;
                    case "4":
                        GetCart();
                        break;
                    case "5":
                        CompletePurchase();
                        break;
                    case "6":
                        stay = false;
                        ExitRemarks();
                        break;
                    case "7":
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please select a menu item");
                        break;
                }
            } while (stay);
        }
        public void CreateCustomer() {
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

            _customerBL.AddCustomer(newCustomer);
            Console.WriteLine("Customer Successfully Created!");
            
        }

        public void GetCustomers() {
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void GetOrderHistory() {

        }

        public void GetCart() {

        }

        public void CompletePurchase() {

        }

        public void ExitRemarks() {
            Console.WriteLine("Exiting Store");
        }
    }
}