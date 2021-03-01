using System;
using System.Security;
using System.Collections.Generic;
using StoreBL;
using StoreDL;
using StoreModels;
namespace StoreUI
{
    class CustomerLoginMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }

        private ICustomerBL _customerBL;
        private Customer _customer;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        private ICustomerCartBL _customerCartBL;
        private ICustomerOrderLineItemBL _customerOrderLineItem;
        private ICustomerOrderHistoryBL _customerOrderHistory;
        public CustomerLoginMenu(ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL, 
                                ICustomerCartBL customerCartBL, ICustomerOrderLineItemBL customerOrderLineItem, ICustomerOrderHistoryBL customerOrderHistory) {
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
            _customerCartBL = customerCartBL;
            _customerOrderLineItem = customerOrderLineItem;
            _customerOrderHistory = customerOrderHistory;
            _menu = "\n" +
                    "\n[0] Sign In" +
                    "\n[1] Register as Customer" +
                    "\n{2] Get Customers" +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }

        public void Start() 
        {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine(_menu);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
                switch (userInput) {
                    case "0":
                        try
                        {
                            if (Login())
                            {
                                menu = new CustomerMenu(_customer, _customerBL, _locationBL, _productBL, _inventoryLineItemsBL, _customerCartBL, _customerOrderLineItem, _customerOrderHistory);
                                menu.Start();
                            }
                            else { _customer = null; }
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine("\nThe provided email is not associated with a customer!");
                            Console.ReadLine();
                            continue;
                        }
                        finally
                        {
                            _customer = null;
                        }
                        break;
                    case "1":
                        try
                        {
                            CreateCustomer();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\ninvalid input." + e.Message);
                            Console.ReadLine();
                            continue;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        GetCustomers();
                        break;
                    /*case "3":
                        DeleteCustomer();
                        break;*/
                    case "Back":
                        stay = false;
                        break;
                    case "Exit":
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input! Please select a menu item");
                        Console.WriteLine("Press Enter to view menu");
                        Console.ReadLine();
                        break;
                }
            } while (stay);
        }

        public void CreateCustomer() 
        {
            _customerBL.AddCustomer(GetCustomerDetails());
            Console.WriteLine("Customer Successfully Created!");
        }

        public void GetCustomers() 
        {
            Console.Clear();
            Console.WriteLine("Customer List---");
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void DeleteCustomer() 
        {
            Console.Write("Enter the customer that you wish to be removed from the roster:\t");
            Customer customer2BDeleted = _customerBL.GetCustomerByEmail(Console.ReadLine());
            if (customer2BDeleted == null)
            {
                Console.WriteLine("We can't find the customer. They may have already been deleted. \n Or you typed their name wrong. This is a case sensitive application.");
            }
            else
            {
                _customerBL.DeleteCustomer(customer2BDeleted);
                Console.WriteLine($"Success!!!! {customer2BDeleted.CustomerName} is gone from your hero collection");
            }
        }

        public bool Login() {
            Console.Clear();
            Console.WriteLine("Sign in---");
            Console.Write("Email:\t\t");
            string userEmail = Console.ReadLine();
            Console.Write("Password:\t");
            string password = GetPassword();
            byte[] hashBytes = Convert.FromBase64String(_customerBL.GetCustomerByEmail(userEmail).CustomerPasswordHash);
            PasswordHash customerPasswordHash = new PasswordHash(hashBytes);
            _customer = _customerBL.GetCustomerByEmail(userEmail);
            return customerPasswordHash.Verify(password);
        }

        public string GetUserPasswordHash(string _userName) {
            foreach (var item in _customerBL.GetCustomers())
            {
                if (item.CustomerEmail == _userName) {
                    _customer = item;
                    return item.CustomerPasswordHash;
                }
            }
            return null;
        }

        //https://stackoverflow.com/questions/3404421/password-masking-console-application
        public string GetPassword()
        {
            string pwd = ""; // = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd = pwd.Remove(pwd.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000' ) // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    //pwd.AppendChar(i.KeyChar);
                    pwd += i.KeyChar;
                    Console.Write("*");
                }
            }
            return pwd;
        }

        private Customer GetCustomerDetails()
        {
            Customer newCustomer = new Customer();
            Console.Clear();
            Console.WriteLine("Register Customer---");
            Console.Write("Customer Name:\n\t");
            newCustomer.CustomerName = Console.ReadLine();
            Console.Write("Email (example.domain.com):\n\t");
            newCustomer.CustomerEmail = Console.ReadLine();
            Console.Write("Password:\n\t");
            string tempPass = GetPassword();
            Console.WriteLine("");
            string confirmPass = null;
            do {
                Console.Write("Confirm Password (must match above):\n\t");
                confirmPass =  GetPassword();
                Console.WriteLine("");
            } while (tempPass != confirmPass);
            PasswordHash passwordHash = new PasswordHash(tempPass);
            newCustomer.CustomerPasswordHash = Convert.ToBase64String(passwordHash.ToArray());
            Console.Write("Phone # (1234567890):\n\t");
            newCustomer.CustomerPhone = Console.ReadLine();
            string newAddress = "";
            Console.WriteLine("Customer Address--");
            Console.Write("\t\tStreet:\t");
            newAddress += Console.ReadLine();
            Console.Write("\t\tCity:\t");
            newAddress += ", " + Console.ReadLine();
            Console.Write("\t\tState:\t");
            newAddress += ", " + Console.ReadLine();
            Console.Write("\t\tZip:\t");
            newAddress += " " + Console.ReadLine();
            newCustomer.CustomerAddress = newAddress;
            return newCustomer;


        }
    }
}
            /*
            
            */