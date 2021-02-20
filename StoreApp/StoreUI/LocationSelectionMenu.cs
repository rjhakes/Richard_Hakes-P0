using System;
using StoreModels;
using StoreBL;
using StoreDL;
using System.Collections.Generic;

namespace StoreUI
{
    public class LocationSelectionMenu : IMenu
    {
        private ILocationBL _locationBL;
        private Location _userLocation;
        private List<Location> locationsList = new List<Location>();
        private IMenu menu;
        public LocationSelectionMenu(ILocationBL locationBL) {
            _locationBL = locationBL;
        }
        public void Start() {
            
            Boolean stay = true;
            do {
                Console.Clear();
                Console.WriteLine("Choose a Location");
                GetLocations();
                Console.WriteLine("[Back] Previous Menu");
                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();
                switch(userInput) {
                    case "0":
                        _userLocation = locationsList[0];
                        menu = new LocationMenu(new LocationBL(new LocationRepoFile()), _userLocation);
                        menu.Start();
                        break;
                    case "1":
                        _userLocation = locationsList[1];
                        menu = new LocationMenu(new LocationBL(new LocationRepoFile()), _userLocation);
                        menu.Start();
                        break;
                    case "2":
                        _userLocation = locationsList[2];
                        menu = new LocationMenu(new LocationBL(new LocationRepoFile()), _userLocation);
                        menu.Start();
                        break;
                    case "3":
                        _userLocation = locationsList[3];
                        menu = new LocationMenu(new LocationBL(new LocationRepoFile()), _userLocation);
                        menu.Start();
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

        public void GetLocations() {
            int i = 0;
            foreach (var item in _locationBL.GetLocations())
            {
                Console.WriteLine($"[{i}] {item.ToString()}");
                locationsList.Add(item);
                i++;
            }
        }
    }
}
