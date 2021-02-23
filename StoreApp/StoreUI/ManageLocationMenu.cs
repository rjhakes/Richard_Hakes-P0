using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class ManageLocationMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private IProductBL _productBL = new ProductBL(new ProductRepoFile());
        private ILocationBL _locationBL;
        private Location _storeLocation;
        public override string MenuPrint {
            get { return _menu; }
        }
        public ManageLocationMenu(ILocationBL locationBL, Location storeLocation) {
            _locationBL = locationBL;
            _storeLocation = storeLocation;
            _menu = "\n" +
                    "\n[0] Add All Products to Inventory" +
                    "\n[1] Add a Product to Inventory" +
                    "\n[2] Replenish Item Quantity" +
                    "\n[3] View Inventory" +
                    "\n[4] View Order History" +    
                    "\n[5] " +
                    "\n[6] " +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }
        public void Start() {
            
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine($"Managing at {_storeLocation.LocationName} Store");
                GetInventory();
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();
                switch(userInput) {
                    case "0":
                        AddAllProductToInventory();
                        break;
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                    case "Back":
                        stay = false;
                        break;
                    case "Exit":
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input! Please select a menu option (0, 1, ..., n, Back)");
                        Console.WriteLine("Press Enter to view menu");
                        Console.ReadLine();
                        break;
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

        public void AddAllProductToInventory() {
            Item newItem;
            foreach (var item in _productBL.GetProducts()) {
                newItem = new Item();
                newItem.Product = item;
                newItem.Quantity = 20;
                _storeLocation.Inventory.Add(newItem);
                
            }
        }
    }
}