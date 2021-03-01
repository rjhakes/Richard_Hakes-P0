using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class CustomerMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }

        private Customer _user;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private Location _location;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        private ICustomerCartBL _customerCartBL;
        private ICustomerOrderLineItemBL _customerOrderLineItem;
        private ICustomerOrderHistoryBL _customerOrderHistory;
        public CustomerMenu(Customer user, ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL, 
                            ICustomerCartBL customerCartBL, ICustomerOrderLineItemBL customerOrderLineItem, ICustomerOrderHistoryBL customerOrderHistory) 
        {
            _user = user;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
            _customerCartBL = customerCartBL;
            _customerOrderLineItem = customerOrderLineItem;
            _customerOrderHistory = customerOrderHistory;
            _menu = $"Account Info--\n\tName:\t\t{_user.CustomerName}\n\tEmail:\t\t{_user.CustomerEmail}\n\tPhone:\t\t{_user.CustomerPhone}\n\tAddress:\t{_user.CustomerAddress}" +

                    "\n" +
                    "\n[1] View My Cart and Finalize Purchase" +
                    "\n[2] View My Order History" +
                    "\n[3] Choose Location and Shop" +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }

        public void Start() {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
                switch (userInput) {
                    case "1":
                        menu = new CustomerCartMenu(_user);
                        menu.Start();
                        break;
                    case "2":
                        Console.Clear();
                        GetCustomerOrderHistory();
                        Console.ReadLine();
                        break;
                    case "3":
                        GetLocations();
                        Console.Write("Choose Location Name:\t");
                        string userLocation = Console.ReadLine();
                        _location = _locationBL.GetLocationByName(userLocation);
                        menu = new CustomerLocationMenu( _user, _customerBL, _location, _locationBL, _productBL, _inventoryLineItemsBL, _customerCartBL, _customerOrderLineItem, _customerOrderHistory);
                        menu.Start();
                        break;
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

        public Customer GetCustomer(string _customerEmail) {
            Console.WriteLine($"Account Info--\n\tName:\t\t{_user.CustomerName}\n\tEmail:\t\t{_user.CustomerEmail}\n\tPhone:\t\t{_user.CustomerPhone}\n\tAddress:\t{_user.CustomerAddress}");
            return null;
        }

        public void GetLocations() {
            Console.Clear();
            foreach (var item in _locationBL.GetLocations()) {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetCustomerOrderHistory() {
            /*foreach (var item in _orderBL.GetOrders()) {
                /*Console.WriteLine("Getting Customer Order History");
                Console.WriteLine(item.ToString());*/
                
                /*if (item.Customer.Equals(_user)) {
                    Console.WriteLine($"{item.ToString()}");//\n---------------");
                    foreach (var lineItem in item.Cart) {
                        Console.WriteLine(lineItem);
                        //need to print total
                    }
                    Console.WriteLine("---------------");
                }
                
            }*/
            
            Console.ReadLine();
        }
    }
}