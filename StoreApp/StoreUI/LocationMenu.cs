using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;

namespace StoreUI
{
    public class LocationMenu : IMenu
    {
        private ILocationBL _locationBL;
        public LocationMenu(ILocationBL locationBL) {
            _locationBL = locationBL;
        }
        public void Start() {
            Boolean stay = true;
            do {
                Console.WriteLine("Choose a Location");

                GetLocations();

                Console.WriteLine("[4] Previous Menu");

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
                    case "4":
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please select a store location");
                        break;
                }
            } while (stay);

            /*stay = true;
            do {

            } while (stay);*/
        }

        public void GetLocations() {
            foreach (var item in _locationBL.GetLocations())
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
