using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer AddCustomer(Customer newCustomer);
        Customer GetCustomerByName(string name);
        Customer DeleteCustomer(Customer customer2BDeleted);
        void UpdateCustomer(Customer customer2BUpdated);
    }
}