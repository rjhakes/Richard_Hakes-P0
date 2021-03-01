using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;
namespace StoreBL
{
    public class CustomerCartBL : ICustomerCartBL
    {
        private ICustomerCartRepository _repo;

        public CustomerCartBL(ICustomerCartRepository repo) {
            _repo = repo;
        }

        public void AddCustomerCart(CustomerCart newCustomerCart)
        {
            //TODO: Add BL
            _repo.AddCustomerCart(newCustomerCart);
        }
        public void DeleteCustomerCart(CustomerCart customerCart2BDeleted)
        {
            _repo.DeleteCustomerCart(customerCart2BDeleted);
        }
        public CustomerCart GetCustomerCartByIds(int customerId, int locId) {
            //todo validate
            return _repo.GetCustomerCartByIds(customerId, locId);
        }
        public List<CustomerCart> GetCustomerCarts()
        {
            //TODO Add BL
            return _repo.GetCustomerCarts();
        }
        public void UpdateCustomerCart(CustomerCart customerCart2BUpdated, CustomerCart updatedDetails)
        {
            customerCart2BUpdated.CustId = updatedDetails.CustId;
            customerCart2BUpdated.LocId = updatedDetails.LocId;
            customerCart2BUpdated.CurrentItemsId = updatedDetails.CurrentItemsId;
            
            _repo.UpdateCustomerCart(customerCart2BUpdated);
        }

    }
}