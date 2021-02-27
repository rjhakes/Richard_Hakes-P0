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
        public void DeleteCustomer(Customer customer2BDeleted)
        {
            _repo.DeleteCustomer(customer2BDeleted);
        }
        public Customer GetCustomerByName(string name) {
            //todo validate
            return _repo.GetCustomerByName(name);
        }
        public List<Customer> GetCustomers()
        {
            //TODO Add BL
            return _repo.GetCustomers();
        }
        public void UpdateCustomer(Customer customer2BUpdated, Customer updatedDetails)
        {
            customer2BUpdated.CustomerName = updatedDetails.CustomerName;
            customer2BUpdated.CustomerEmail = updatedDetails.CustomerEmail;
            customer2BUpdated.CustomerPasswordHash = updatedDetails.CustomerPasswordHash;
            customer2BUpdated.CustomerPhone = updatedDetails.CustomerPhone;
            customer2BUpdated.CustomerAddress = updatedDetails.CustomerAddress;

            _repo.UpdateCustomer(customer2BUpdated);
        }

        
    }
}
