using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class CustomerMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private ILocationBL _locationBL = new LocationBL(new LocationRepoFile());
        private IProductBL _productBL = new ProductBL(new ProductRepoFile());
        private ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
        public override string MenuPrint {
            get { return _menu; }
        }

        private Customer _user;
        private Location _location;
        public CustomerMenu(Customer user) {
            _user = user;
            _menu = "\n" +
                    "\n[0] View My Account Information" +
                    "\n{1] View My Cart and Finalize Purchase" +
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
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Account Information:\n");
                        FindCustomer(_user.CustEmail);
                        Console.ReadLine();
                        break;
                    case "1":
                        menu = new CustomerCartMenu(_user);
                        menu.Start();
                        break;
                    case "2":
                        /*Console.Clear();
                        GetCustomers();*/
                        break;
                    case "3":
                        GetLocations();
                        Console.Write("Choose Location Name:\t");
                        string userLocation = Console.ReadLine();
                        _location = ChooseLocation(userLocation);
                        menu = new CustomerLocationMenu(_locationBL, _location, _user);
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

        public Customer FindCustomer(string _customerEmail) {
            ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
            foreach (var item in _customerBL.GetCustomers())
            {
                if (item.CustEmail == _customerEmail) {
                    Console.WriteLine(item);
                    return item;
                }
            }
            return null;
        }

        public void GetLocations() {
            foreach (var item in _locationBL.GetLocations()) {
                Console.WriteLine(item.ToString());
            }
            // Console.WriteLine("Press any key to continue");
            // Console.ReadLine();
        }

        public Location ChooseLocation(string _locationName) {
            foreach (var item in _locationBL.GetLocations())
            {
                if (item.LocationName == _locationName) {
                    Console.WriteLine(item);
                    return item;
                }
            }
            return null;
        }
    }
}