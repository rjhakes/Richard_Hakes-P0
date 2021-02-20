using System.Collections.Generic;
using StoreModels;

namespace StoreDL
{
    public class Storage
    {
        public static List<Customer> AllCustomers = new List<Customer>();
        public static List<Product> AllProducts = new List<Product>();
        public static List<Location> AllLocations = new List<Location>();
        public static List<Manager> AllManagers = new List<Manager>();
        public static List<Order> AllOrders = new List<Order>();
    }
}