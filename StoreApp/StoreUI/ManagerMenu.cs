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
        private ILocationBL _locationBL = new LocationBL(new LocationRepoFile());
        private IProductBL _productBL = new ProductBL(new ProductRepoFile());
        private ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
        private Manager _manager;
        private Location _location;
        public override string MenuPrint {
            get { return _menu; }
        }
                
        public ManagerMenu(Manager manager) {
            _manager = manager;
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
                Console.WriteLine($"Welcome {_manager.ManagerName}\n");
                Console.WriteLine(MenuPrint);
                Console.WriteLine("Enter a #, 'Back' or 'Exit': ");
                string userInput = Console.ReadLine();

                IMenu menu;
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
                        GetCustomers();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
                        break;
                    case "2":
                        GetLocations();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadLine();
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
                        _location = ChooseLocation(userLocation);
                        menu = new ManageLocationMenu(_locationBL, _location);
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

        public Customer FindCustomer(string _customerEmail) {
            //ICustomerBL _customerBL = new CustomerBL(new CustomerRepoFile());
            foreach (var item in _customerBL.GetCustomers())
            {
                if (item.CustEmail == _customerEmail) {
                    Console.WriteLine(item);
                    return item;
                }
            }
            return null;
        }

        public void GetCustomers() {
            foreach (var item in _customerBL.GetCustomers())
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetLocations() {
            foreach (var item in _locationBL.GetLocations()) {
                Console.WriteLine(item.ToString());
            }
            // Console.WriteLine("Press any key to continue");
            // Console.ReadLine();
        }

        public void CreateLocation() {
            
            Location newLocation = new Location();
            Console.WriteLine("Enter Location Name: ");
            newLocation.LocationName = Console.ReadLine();
            Console.WriteLine("Enter Location Address: ");
            Address newAddress = new Address();
            Console.WriteLine("Street:");
            newAddress.Street = Console.ReadLine();
            Console.WriteLine("City:");
            newAddress.City = Console.ReadLine();
            Console.WriteLine("State:");
            newAddress.State = Console.ReadLine();
            Console.WriteLine("Country:");
            newAddress.Country = Console.ReadLine();
            Console.WriteLine("Postal Code:");
            newAddress.PostalCode = Console.ReadLine();
            newLocation.Address = newAddress;
            List<Item> inventory = new List<Item>();
            Item newItem;
            foreach (var item in _productBL.GetProducts()) {
                newItem = new Item();
                newItem.Product = item;
                newItem.Quantity = 20;
                inventory.Add(newItem);
            }
            newLocation.Inventory = inventory;
            _locationBL.AddLocation(newLocation);
        }

        public void GetProducts() {
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
            newProduct.ProductName = Console.ReadLine();
            Console.Write("Price:\t\t");
            newProduct.ProductPrice = double.Parse(Console.ReadLine());
            Console.Write("\nCategory List:" +
                "\nBrakes\t\tExhaust\t\tIntake\t\tDrivetrain" +
                "\nForcedInduction\tStyling\t\tEngine\t\tFueling" +
                "\nSuspension\tTuningAndGuages\tWheels\t\tAccessories\n\n");
            Console.Write("Category:\t\t");
            newProduct.CategoryType = Enum.Parse<Category>(Console.ReadLine()); 
            Console.Write("Brand Name:\t");
            newProduct.BrandName = Console.ReadLine();
            _productBL.AddProduct(newProduct);

        }

        public Location ChooseLocation(string _locationName) {
            foreach (var item in _locationBL.GetLocations())
            {
                if (item.LocationName == _locationName) {
                    Console.WriteLine(item);
                    return item;
                }
            }
            return null;
        }
    }
}