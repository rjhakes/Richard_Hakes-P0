using System;
using StoreModels;
using StoreBL;
using StoreDL;
using System.Collections.Generic;
namespace StoreUI
{
    class ManagerLoginMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }

        private IManagerBL _managerBL;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        private Manager _manager;

        public ManagerLoginMenu(IManagerBL managerBL, ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL) {
            _managerBL = managerBL;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
            _menu = "\n" +
                    "\n[0] Sign In" +
                    "\n[1] Register as Manager" +
                    "\n{2] Get Managers" +
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
                        try
                        {
                            if (Login())
                            {
                                menu = new ManagerMenu(_manager, _managerBL, _customerBL, _locationBL, _productBL, _inventoryLineItemsBL);
                                menu.Start();
                            }
                            else { _manager = null; }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\nThe provided email is not associated with a manager!");
                            Console.ReadLine();
                            continue;
                        }
                        finally
                        {
                            _manager = null;
                        }
                        break;
                    case "1":
                        try
                        {
                            CreateManager();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("\ninvalid input. ");
                            Console.ReadLine();
                            continue;
                        }
                        
                        break;
                    case "2":
                        Console.Clear();
                        GetManagers();
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
        public void CreateProduct() {

        }
        public void ExitRemarks() {
            Console.WriteLine("Exiting Store");
        }

        public void CreateManager() {
            _managerBL.AddManager(GetManagerDetails());
            Console.WriteLine("Manager Successfully Created!");
            Console.ReadLine();
        }

        public void GetManagers() {
            Console.Clear();
            Console.WriteLine("Manager List---");
            foreach (var item in _managerBL.GetManagers())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public bool Login() {
            Console.Clear();
            Console.WriteLine("Sign in---");
            Console.Write("Email:\t\t");
            string userEmail = Console.ReadLine();
            Console.Write("Password:\t");
            string password = GetPassword();
            byte[] hashBytes = Convert.FromBase64String(_managerBL.GetManagerByEmail(userEmail).ManagerPasswordHash);
            PasswordHash managerPasswordHash = new PasswordHash(hashBytes);
            _manager = _managerBL.GetManagerByEmail(userEmail);
            return managerPasswordHash.Verify(password);
        }

        public string GetManagerPasswordHash(string _userName) {
            foreach (var item in _managerBL.GetManagers())
            {
                if (item.ManagerEmail == _userName) {
                    _manager = item;
                    return item.ManagerPasswordHash;
                }
            }
            return null;
        }

        //https://stackoverflow.com/questions/3404421/password-masking-console-application
        public string GetPassword()
        {
            string pwd = ""; // = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd = pwd.Remove(pwd.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000' ) // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    //pwd.AppendChar(i.KeyChar);
                    pwd += i.KeyChar;
                    Console.Write("*");
                }
            }
            return pwd;
        }

        private Manager GetManagerDetails()
        {
            Manager newManager = new Manager();
            Console.Clear();
            Console.WriteLine("Register Manager---");
            Console.Write("Manager Name:\n\t");
            newManager.ManagerName = Console.ReadLine();
            Console.Write("Email (example@domain.com):\n\t");
            newManager.ManagerEmail = Console.ReadLine();
            Console.Write("Password:\n\t");
            string tempPass = GetPassword();
            Console.WriteLine("");
            string confirmPass = null;
            do {
                Console.Write("Confirm Password (must match above):\n\t");
                confirmPass = GetPassword();
                Console.WriteLine("");
            } while (tempPass != confirmPass);
            
            PasswordHash passwordHash = new PasswordHash(tempPass);
            newManager.ManagerPasswordHash = Convert.ToBase64String(passwordHash.ToArray());
            Console.Write("Phone # (1234567890):\n\t");
            newManager.ManagerPhone = Console.ReadLine();
            Console.Write("Store ID:\n\t");
            newManager.ManagerLocId = int.Parse(Console.ReadLine());
            return newManager;
            
        }
    }
}