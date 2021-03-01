using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class ManageLocationMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private ILocationBL _locationBL;
        private Location _location;
        private Manager _user;
        private IManagerBL _managerBL;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        public override string MenuPrint {
            get { return _menu; }
        }
        public ManageLocationMenu(Manager user, IManagerBL managerBL, Location location, ILocationBL locationBL, IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL) {
            _locationBL = locationBL;
            _location = location;
            _user = user;
            _managerBL = managerBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
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
                Console.WriteLine($"Managing at {_location.LocName} Store");
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
                        GetInventory();
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
            Console.WriteLine("Product Details-----");
            foreach (var item in _inventoryLineItemsBL.GetInventoryLineItems())
            {
                if (item.InventoryId == _location.Id)
                {
                    Console.WriteLine($"[{i}] {_productBL.GetProductById((int)item.ProductId)} {item.ToString()}");
                    i++;
                }
                
            }
        }

        public void AddAllProductToInventory() {
            Console.WriteLine("adding products");
            Console.ReadLine();
            foreach (var item in _productBL.GetProducts()) {
                Console.WriteLine(item.ToString());
            }
        }

        public InventoryLineItem GetItemDetails(Product item)
        {
            InventoryLineItem newLineItem = new InventoryLineItem();
            newLineItem.InventoryId = _location.Id;
            newLineItem.ProductId = item.Id;
            newLineItem.Quantity = 20;
            return newLineItem;
        }
    }
}