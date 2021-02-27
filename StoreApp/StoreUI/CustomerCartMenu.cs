using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class CustomerCartMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }

        private Customer _user;
        public CustomerCartMenu(Customer user) {
            _user = user;
            _menu = "\n" +
                    "\n[0] Finalize Purchase" +
                    "\n{1] Modify Order" +
                    "\n[2] " +
                    "\n[3] " +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }

        public void Start() {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine("Customer Cart");
                /*foreach(var item in _user.CustCart) {
                    Console.WriteLine(item);
                }*/
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
                switch (userInput) {
                    case "0":
                        
                        break;
                    case "1":
                        menu = new CustomerCartMenu(_user);
                        menu.Start();
                        break;
                    /*case "2":
                        Console.Clear();
                        GetCustomers();
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
    }
}