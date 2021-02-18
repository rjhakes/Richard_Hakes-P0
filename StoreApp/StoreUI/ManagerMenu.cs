using System;
using StoreModels;
using StoreBL;
using StoreDL;
using System.Collections.Generic;
namespace StoreUI
{
    public class ManagerMenu : IMenu
    {
        private ILocationBL _locationBL = new LocationBL(new LocationRepoFile());
        public void Start() {
            Boolean stay = true;
            do {
                Console.WriteLine("[0] Add Location");
                Console.WriteLine("[1] Add Product");
                Console.WriteLine("[2] Return to previous menu.");

                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        CreateLocation();
                        break;
                    case "1":
                        CreateProduct();
                        break;
                    case "2":
                        stay = false;
                        ExitRemarks();
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please select a menu item");
                        break;
                }
            } while (stay);
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
            newLocation.Inventory = inventory;
            _locationBL.AddLocation(newLocation);
        }
        public void CreateProduct() {

        }
        public void ExitRemarks() {
            Console.WriteLine("Exiting Store");
        }
    }
}