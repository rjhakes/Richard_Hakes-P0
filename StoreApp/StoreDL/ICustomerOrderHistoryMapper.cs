using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface ICustomerOrderHistoryMapper
    {
        Model.CustomerOrderHistory ParseCustomerOrderHistory(Entity.CustomerOrderHistory customerOrderHistory);
        Entity.CustomerOrderHistory ParseCustomerOrderHistory(Model.CustomerOrderHistory customerOrderHistory);
    }
}