using System;
using StoreBL;
using StoreDL;
using StoreModels;
namespace StoreUI
{
    class StoreFrontMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }

        public StoreFrontMenu() {
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
                        menu = new CustomerLoginMenu(new CustomerBL(new CustomerRepoFile()));
                        menu.Start();
                        break;
                    case "1":
                        menu = new ManagerLoginMenu(new ManagerBL(new ManagerRepoFile()));
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