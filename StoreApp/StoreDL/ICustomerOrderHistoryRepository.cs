using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerOrderHistoryRepository
    {
        List<CustomerOrderHistory> GetCustomerOrderHistories();
        CustomerOrderHistory AddCustomerOrderHistory(CustomerOrderHistory newCustomerOrderHistory);
        CustomerOrderHistory GetCustomerOrderHistoryById(int id);
        CustomerOrderHistory DeleteCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BDeleted);
        void UpdateCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BUpdated);
    }
}