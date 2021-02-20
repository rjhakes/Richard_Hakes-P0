using System;
using System.Security.Cryptography;
using System.Security;
using StoreBL;
using StoreDL;
using StoreModels;
namespace StoreUI
{
    class CustomerLoginMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }

        private ICustomerBL _customerBL;
        private Customer _customer;
        public CustomerLoginMenu(ICustomerBL customerBL) {
            _customerBL = customerBL;
            _menu = "\n" +
                    "\n[0] Sign In" +
                    "\n[1] Register as Customer" +
                    //"\n{2] Get Customers" +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }

        public void Start() {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine(_menu);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
                switch (userInput) {
                    case "0":
                        Login();
                        break;
                    case "1":
                        CreateCustomer();
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

        public void CreateCustomer() {
            Customer newCustomer = new Customer();
            Console.Clear();
            Console.WriteLine("Register as Customer---");
            Console.Write("Customer Name:\n\t");
            newCustomer.CustName = Console.ReadLine();
            Console.Write("User Name:\n\t");
            newCustomer.UserName = Console.ReadLine();
            Console.Write("Password:\n\t");
            //newCustomer.CustName = Console.ReadLine();
            string tempPass = Console.ReadLine();
            string confirmPass = null;
            do {
                Console.Write("Confirm Password (must match above):\n\t");
                confirmPass = Console.ReadLine();
            } while (tempPass != confirmPass);
            
            //https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
            //Create the salt value with a cryptographic PRNG:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //Create the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(tempPass, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combine the salt and password bytes for later use:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //Turn the combined salt+hash into a string for storage
            newCustomer.SavedPasswordHash = Convert.ToBase64String(hashBytes);
            //DBContext.AddUser(new User { ..., Password = savedPasswordHash });
            //newCustomer.CustName = Console.ReadLine();
            Console.Write("Email (example@domain.com):\n\t");
            newCustomer.CustEmail = Console.ReadLine();
            Console.Write("Phone # (1234567890):\n\t");
            newCustomer.CustPhoneNumber = Console.ReadLine(); 
            Console.WriteLine("Shipping Address");
            Address newAddress = new Address();
            Console.Write("\tStreet:\t\t\t");
            newAddress.Street = Console.ReadLine();
            Console.Write("\tCity:\t\t\t");
            newAddress.City = Console.ReadLine();
            Console.Write("\tState:\t\t\t");
            newAddress.State = Console.ReadLine();
            Console.Write("\tCountry:\t\t");
            newAddress.Country = Console.ReadLine();
            Console.Write("\tPostal Code:\t\t");
            newAddress.PostalCode = Console.ReadLine();
            newCustomer.CustShipAddress = newAddress;
            Console.Write("Is the Customer's Billing Address the same as Shipping? (y/n):");
            if (Console.ReadLine()[0] == 'y') {
                newCustomer.CustBillAddress = newCustomer.CustShipAddress;
            } else {
                newAddress = new Address();
                Console.Write("\tStreet:\t\t\t");
                newAddress.Street = Console.ReadLine();
                Console.Write("\tCity:\t\t\t");
                newAddress.City = Console.ReadLine();
                Console.Write("\tState:\t\t\t");
                newAddress.State = Console.ReadLine();
                Console.Write("\tCountry:\t\t");
                newAddress.Country = Console.ReadLine();
                Console.Write("\tPostal Code:\t\t");
                newAddress.PostalCode = Console.ReadLine();
                newCustomer.CustBillAddress = newAddress;
            }
            _customerBL.AddCustomer(newCustomer);
            Console.WriteLine("Customer Successfully Created!");
        }

        public void GetCustomers() {
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void Login() {
            //http://csharptest.net/470/another-example-of-how-to-store-a-salted-password-hash/
            //https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
            Console.Clear();
            Console.WriteLine("Sign in---");
            Console.Write("User Name:\t\t");
            string userName = Console.ReadLine();
            Console.Write("Password:\t\t");
            string password = GetPassword();

            //Verify the user-entered password against a stored password
            /* Fetch the stored value */
            //string savedPasswordHash = DBContext.GetUser(u => u.UserName == user).Password;
            /* Extract the bytes */
            //byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] hashBytes = Convert.FromBase64String(GetUserSavedPasswordHash(userName));
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i=0; i < 20; i++) {
                if (hashBytes[i+16] != hash[i]) { 
                    Console.WriteLine("Incorrect User Name or Password \nPress Enter");
                    Console.ReadLine();
                }
                else {
                    IMenu menu = new CustomerMenu(_customer);
                    menu.Start(); 
                    i = 20;
                }
            }
        }

        public string GetUserSavedPasswordHash(string _userName) {
            foreach (var item in _customerBL.GetCustomers())
            {
                if (item.UserName == _userName) {
                    _customer = item;
                    return item.SavedPasswordHash;
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
    }
}