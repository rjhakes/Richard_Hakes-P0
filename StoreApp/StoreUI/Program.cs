using System;
using StoreModels;
using StoreBL;
using StoreDL;
using System.Collections.Generic;
namespace StoreUI
{
    class Program
    {
        static void Main(string[] args)
        {   
            Boolean stay = true;
            do {
                Console.WriteLine("Welcome to my Store App! \nAre you a customer or manager?");
                Console.WriteLine("[0] Customer");
                Console.WriteLine("[1] Manager");
                Console.WriteLine("[2] Exit App");

                Console.WriteLine("Enter a number: ");
                string userInput = Console.ReadLine();

                switch (userInput) {
                    case "0":
                        IMenu menu = new CustomerMenu(new CustomerBL(new CustomerRepoFile()));
                        menu.Start();
                        break;
                    case "1":
                        menu = new ManagerMenu();
                        menu.Start();
                        break;
                    case "2":
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please select a menu item");
                        break;
                }
            } while (stay);
            
            /*
            
            */
        }
    }
}