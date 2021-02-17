using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public class CustomerRepoSC : ICustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            return Storage.AllCustomers;
        }
        public Customer AddCustomer(Customer newCustomer)
        {
            Storage.AllCustomers.Add(newCustomer);
            return newCustomer;
        }
    }
}