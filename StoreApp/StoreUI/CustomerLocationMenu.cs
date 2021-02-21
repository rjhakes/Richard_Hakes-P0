using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class CustomerLocationMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private IProductBL _productBL = new ProductBL(new ProductRepoFile());
        private ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
        private ILocationBL _locationBL;
        private Location _storeLocation;
        private Customer _user;
        
        public override string MenuPrint {
            get { return _menu; }
        }
        public CustomerLocationMenu(ILocationBL locationBL, Location storeLocation, Customer user) {
            _locationBL = locationBL;
            _storeLocation = storeLocation;
            _user = user;
            _menu = "\n" +
                    "\n[View] View Cart" +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }
        public void Start() {
            
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine($"Shopping at {_storeLocation.LocationName} Store");
                Console.WriteLine(_user);
                GetInventory();
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter an item number to place item in cart: ");
                string userInput = Console.ReadLine();
                if (userInput != "View" && userInput != "Back" && userInput != "Exit") {
                    OrderItem(userInput);
                } else {
                    switch(userInput) {
                        case "View":
                            ViewCart();
                            break;
                        case "Back":
                            stay = false;
                            break;
                        case "Exit":
                            System.Environment.Exit(1);
                            break;
                        default:
                            
                            break;
                    }
                }
                
            } while (stay);
        }

        public void GetInventory() {
            int i = 0;
            foreach (var item in _storeLocation.Inventory)
            {
                Console.WriteLine($"[{i}] {item.ToString()}");
                i++;
            }
        }

        public void OrderItem(string _item) {
            Console.WriteLine("In Order Item");
            int i = int.Parse(_item);
            _user.CustCart.Add(_storeLocation.Inventory[i]);
        }

        public void ViewCart() {
            foreach (var item in _user.CustCart) {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}