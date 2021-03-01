using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class CustomerOrderHistoryMapper : ICustomerOrderHistoryMapper
    {
        public Model.CustomerOrderHistory ParseCustomerOrderHistory(Entity.CustomerOrderHistory customerOrderHistory)
        {
            return new Model.CustomerOrderHistory
            {
                LocId = customerOrderHistory.LocId,
                CustId = customerOrderHistory.CustId,
                OrderDate = customerOrderHistory.OrderDate,
                OrderId = customerOrderHistory.OrderId,
                Total = customerOrderHistory.Total,
                Id = customerOrderHistory.Id
            };
        }

        public Entity.CustomerOrderHistory ParseCustomerOrderHistory(Model.CustomerOrderHistory customerOrderHistory)
        {
            if (customerOrderHistory.Id == null)
            {
                return new Entity.CustomerOrderHistory
                {
                    LocId = customerOrderHistory.LocId,
                    CustId = customerOrderHistory.CustId,
                    OrderDate = customerOrderHistory.OrderDate,
                    OrderId = customerOrderHistory.OrderId,
                    Total = customerOrderHistory.Total,
                };
            }

            return new Entity.CustomerOrderHistory
            {
                LocId = customerOrderHistory.LocId,
                CustId = customerOrderHistory.CustId,
                OrderDate = customerOrderHistory.OrderDate,
                OrderId = customerOrderHistory.OrderId,
                Total = customerOrderHistory.Total,
                Id = (int)customerOrderHistory.Id
            };
        }
    }
}