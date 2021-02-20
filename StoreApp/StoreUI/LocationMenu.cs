using System;
using StoreModels;
using StoreBL;
namespace StoreUI
{
    public class LocationMenu : IMenu
    {
        private ILocationBL _locationBL;
        private Location _userLocation;
        public LocationMenu(ILocationBL locationBL, Location userLocation) {
            _locationBL = locationBL;
            _userLocation = userLocation;
        }
        public void Start() {
            
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine($"Shopping at {_userLocation.LocationName}");
                PrintInventory();
                Console.WriteLine("[Back] Previous Menu");
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();
                switch(userInput) {
                    case "0":
                        
                        break;
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                    case "Back":
                        stay = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input! Please select a menu option (0, 1, ..., n, Back)");
                        Console.WriteLine("Press Enter to view menu");
                        Console.ReadLine();
                        break;
                }
            } while (stay);
            do {

            } while (stay);
        }

        public void PrintInventory() {
            int i = 0;
            foreach (var item in _userLocation.Inventory)
            {
                Console.WriteLine($"[{i}] {item.ToString()}");
                i++;
            }
        }
    }
}