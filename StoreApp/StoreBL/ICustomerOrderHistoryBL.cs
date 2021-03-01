using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ICustomerOrderHistoryBL
    {
        List<CustomerOrderHistory> GetCustomerOrderHistories();
        void AddCustomerOrderHistory(CustomerOrderHistory newCustomerOrderHistory);
        CustomerOrderHistory GetCustomerOrderHistoryById(int id);
        void DeleteCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BDeleted);
        void UpdateCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BUpdated, CustomerOrderHistory updatedDetails);
    }
}