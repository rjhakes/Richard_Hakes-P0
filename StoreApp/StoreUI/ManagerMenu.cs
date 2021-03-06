using System;
using System.Collections.Generic;
using StoreModels;
using StoreBL;
using StoreDL;
namespace StoreUI
{
    class ManagerMenu : AMenu, IMenu
    {
        private readonly string _menu;
        public override string MenuPrint {
            get { return _menu; }
        }
        private Manager _user;
        private IManagerBL _managerBL;
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IProductBL _productBL;
        private IInventoryLineItemBL _inventoryLineItemsBL;
        private Location _location;
        public ManagerMenu(Manager manager, IManagerBL managerBL, ICustomerBL customerBL, ILocationBL locationBL, IProductBL productBL, IInventoryLineItemBL inventoryLineItemsBL) {
            _user = manager;
            _managerBL = managerBL;
            _customerBL = customerBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryLineItemsBL = inventoryLineItemsBL;
            _menu = "\n" +
                    "\n[0] Find Customer" +
                    "\n[1] View Customers" +
                    "\n[2] View Locations" +
                    "\n[3] Add Locations" +
                    "\n[4] View Products" +
                    "\n[5] Add Product" +
                    "\n[6] Choose Location" +
                    "\n[Back] Previous Menu" +
                    "\n[Exit] Exit App";
        }

        public void Start() {
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine($"Welcome {_user.ManagerName}");
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
                switch (userInput) {
                    case "0":
                        try {
                            SearchCustomers();
                            
                        } catch (Exception e) 
                        {
                            Console.WriteLine($"We have no record of {userInput} as a Customer");
                        } finally 
                        {
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "1":
                        try
                        {
                            GetCustomers();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Exception: {e}");
                        }
                        finally
                        {
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                        }
                        
                        break;
                    case "2":
                        try
                        {
                            GetLocations();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Exception: {e}");
                        }
                        finally
                        {
                            Console.WriteLine("Press any key to continue");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        CreateLocation();
                        break;
                    case "4":
                        GetProducts();
                        Console.ReadLine();
                        break;
                    case "5":
                        CreateProduct();
                        break;
                    case "6":
                        GetLocations();
                        Console.Write("Choose Location Name:\t");
                        string userLocation = Console.ReadLine();
                        _location = _locationBL.GetLocationByName(userLocation);
                        menu = new ManageLocationMenu(_user, _managerBL, _location, _locationBL, _productBL, _inventoryLineItemsBL);
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

        public void SearchCustomers()
        {
            Console.Clear();
            Console.Write("Enter Customer Email:\t");
            Customer foundCustomer = _customerBL.GetCustomerByEmail(Console.ReadLine());
            if(foundCustomer == null) {
                Console.WriteLine("No such customer found");
            } else {
                Console.Clear();
                Console.WriteLine("Customer Details---");
                Console.WriteLine(foundCustomer.ToString());
            }
        }

        public void GetCustomers() {
            Console.Clear();
            Console.WriteLine("Customer List---");
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetLocations() 
        {
            Console.Clear();
            Console.WriteLine("Location List---");
            foreach (var item in _locationBL.GetLocations()) {
                Console.WriteLine(item.ToString());
            }

        }

        public void CreateLocation() 
        {
            _locationBL.AddLocation(GetLocationDetails());
            Console.WriteLine("Location Successfully Created!");
        }

        public void GetProducts() 
        {
            foreach (var item in _productBL.GetProducts())
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public void CreateProduct() {
            
            Product newProduct = new Product();
            Console.Write("Product Name:\t");
            newProduct.ProdName = Console.ReadLine();
            Console.Write("Price:\t\t");
            newProduct.ProdPrice = double.Parse(Console.ReadLine());
            Console.Write("\nCategory List:" +
                "\nBrakes\t\tExhaust\t\tIntake\t\tDrivetrain" +
                "\nForcedInduction\tStyling\t\tEngine\t\tFueling" +
                "\nSuspension\tTuningAndGuages\tWheels\t\tAccessories\n\n");
            Console.Write("Category:\t\t");
            newProduct.ProdCategory = Enum.Parse<Category>(Console.ReadLine()); 
            Console.Write("Brand Name:\t");
            newProduct.ProdBrandName = Console.ReadLine();
            _productBL.AddProduct(newProduct);

        }

        private Location GetLocationDetails()
        {
            Location newLocation = new Location();
            Console.WriteLine("Enter Location Name:\n\t");
            newLocation.LocName = Console.ReadLine();
            Console.Write("Enter Location Phone:\n\t");
            newLocation.LocPhone = Console.ReadLine();
            string newAddress = "";
            Console.WriteLine("Enter Customer Address--");
            Console.Write("\t\tStreet:\t");
            newAddress += Console.ReadLine();
            Console.Write("\t\tCity:\t");
            newAddress += ", " + Console.ReadLine();
            Console.Write("\t\tState:\t");
            newAddress += ", " + Console.ReadLine();
            Console.Write("\t\tZip:\t");
            newAddress += " " + Console.ReadLine();
            newLocation.LocAddress = newAddress;
            return newLocation;
        }
    }
}