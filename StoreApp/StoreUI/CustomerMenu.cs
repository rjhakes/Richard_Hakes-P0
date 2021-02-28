using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class CustomerMenu : AMenu, IMenu
    {
        private readonly string _menu;
        //private ILocationBL _locationBL = new LocationBL(new LocationRepoFile());
        //private IProductBL _productBL = new ProductBL(new ProductRepoFile());
        //private ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
        //private IOrderBL _orderBL = new OrderBL(new OrderRepoFile());
        public override string MenuPrint {
            get { return _menu; }
        }

        private Customer _user;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private Location _location;
        public CustomerMenu(Customer user, ICustomerBL customerBL, ILocationBL locationBL) {
            _user = user;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _menu = $"Account Info--\n\tName:\t\t{_user.CustomerName}\n\tEmail:\t\t{_user.CustomerEmail}\n\tPhone:\t\t{_user.CustomerPhone}\n\tAddress:\t{_user.CustomerAddress}" +

                    "\n" +
                    //"\n[0] View My Account Information" +
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
                    /*case "0":
                        Console.Clear();
                        Console.WriteLine("Account Information:\n");
                        GetCustomer(_user.CustomerEmail);
                        Console.ReadLine();
                        break;*/
                    case "1":
                        //Implement CustomerCartMenu
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
                        menu = new CustomerLocationMenu( _user, _customerBL, _location, _locationBL);
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
            //ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
            /*foreach (var item in _customerBL.GetCustomers())
            {
                if (item.CustomerEmail == _customerEmail) {
                    Console.WriteLine(item);
                    return item;
                }
            }*/
            Console.WriteLine($"Account Info--\n\tName:\t\t{_user.CustomerName}\n\tEmail:\t\t{_user.CustomerEmail}\n\tPhone:\t\t{_user.CustomerPhone}\n\tAddress:\t{_user.CustomerAddress}");
            return null;
        }

        public void GetLocations() {
            /*foreach (var item in _locationBL.GetLocations()) {
                Console.WriteLine(item.ToString());
            }*/
            // Console.WriteLine("Press any key to continue");
            // Console.ReadLine();
        }

        public Location ChooseLocation(string _locationName) {
            /*foreach (var item in _locationBL.GetLocations())
            {
                if (item.LocationName == _locationName) {
                    Console.WriteLine(item);
                    return item;
                }
            }*/
            return null;
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