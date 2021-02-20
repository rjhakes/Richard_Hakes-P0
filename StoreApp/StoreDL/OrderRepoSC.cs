using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class OrderRepoSC
    {
        public List<Order> GetOrders()
        {
            return Storage.AllOrders;
        }
        public Order AddOrder(Order newOrder)
        {
            Storage.AllOrders.Add(newOrder);
            return newOrder;
        }
    }
}