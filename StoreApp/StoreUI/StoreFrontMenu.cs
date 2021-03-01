using System;
using StoreBL;
using StoreDL;
using Entity = StoreDL.Entities;
using StoreModels;
namespace StoreUI
{
    class StoreFrontMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private readonly Entity.StoreDBContext _context;
        public override string MenuPrint {
            get { return _menu; }
        }

        private IManagerBL _managerBL;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        public StoreFrontMenu(IManagerBL managerBL, ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL) {
            _managerBL = managerBL;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
            _menu = "\nWelcome to my Store App! \nAre you a customer or manager?" +
                    "\n[0] Customer" +
                    "\n[1] Manager" +
                    "\n[Exit] Exit";
        }

        public void Start() {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine(_menu);
                Console.WriteLine("Enter a number or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
                switch (userInput) {
                    case "0":
                        menu = new CustomerLoginMenu(_customerBL, _locationBL, _productBL, _inventoryLineItemsBL);
                        menu.Start();
                        break;
                    case "1":
                        menu = new ManagerLoginMenu(_managerBL, _customerBL, _locationBL, _productBL, _inventoryLineItemsBL);
                        menu.Start();
                        break;
                    case "Exit":
                        stay = false;
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
    }
}