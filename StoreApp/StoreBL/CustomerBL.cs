using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository repo = new CustomerRepoSC();
        public void AddCustomer(Customer newCustomer)
        {
            //TODO: Add BL
            repo.AddCustomer(newCustomer);
        }
        public List<Customer> GetCustomers()
        {
            //TODO Add BL
            return repo.GetCustomers();
        }
    }
}
