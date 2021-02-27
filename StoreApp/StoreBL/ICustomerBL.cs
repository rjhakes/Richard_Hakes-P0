using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface ICustomerBL
    {
        List<Customer> GetCustomers();
        void AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string name);
        void DeleteCustomer(Customer customer2BDeleted);
        void UpdateCustomer(Customer customer2BUpdated, Customer updatedDetails);
    }
}