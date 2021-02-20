using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;
namespace StoreBL
{
    public class OrderBL : IOrderBL
    {
        private IOrderRepository _repo;

        public OrderBL(IOrderRepository repo) {
            _repo = repo;
        }

        public void AddOrder(Order newOrder)
        {
            //TODO: Add BL
            _repo.AddOrder(newOrder);
        }
        public List<Order> GetOrders()
        {
            //TODO Add BL
            return _repo.GetOrders();
        }
    }
}