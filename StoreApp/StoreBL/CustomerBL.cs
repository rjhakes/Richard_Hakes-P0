using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private ICustomerRepository _repo;

        public CustomerBL(ICustomerRepository repo) {
            _repo = repo;
        }

        public void AddCustomer(Customer newCustomer)
        {
            //TODO: Add BL
            _repo.AddCustomer(newCustomer);
        }
        public List<Customer> GetCustomers()
        {
            //TODO Add BL
            return _repo.GetCustomers();
        }
    }
}
