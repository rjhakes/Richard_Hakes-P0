using System;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class ManagerMenu : AMenu, IMenu
    {
        private readonly string _menu;
        private Manager _manager;
        public override string MenuPrint {
            get { return _menu; }
        }

        
        public ManagerMenu(Manager manager) {
            _manager = manager;
            _menu = "\n" +
                    "\n[0] Find Customer" +
                    "\n[1] " +
                    "\n{2] " +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }

        public void Start() {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine($"Welcome {_manager.ManagerName}\n");
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                switch (userInput) {
                    case "0":
                        Console.Clear();
                        Console.Write("Find Customer\n\tEmail:\t");
                        try {
                            userInput = Console.ReadLine();
                            Customer _customer = FindCustomer(userInput);
                            _customer.ToString();
                        } catch (Exception e) {
                            //log.WriteLine(e);
                            Console.WriteLine($"We have no record of {userInput} as a Customer");
                        } finally {
                            Console.ReadLine();
                        }
                        break;
                    case "1":
                        //CreateManager();
                        break;
                    case "2":
                        //Console.Clear();
                        //GetManagers();
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
    }
}