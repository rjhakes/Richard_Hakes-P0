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
            IMenu menu = new StoreFrontMenu();
            menu.Start();
        }
    }
}
