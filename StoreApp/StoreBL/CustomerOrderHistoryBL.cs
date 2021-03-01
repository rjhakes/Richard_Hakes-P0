using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;
namespace StoreBL
{
    public class CustomerOrderHistoryBL : ICustomerOrderHistoryBL
    {
        private ICustomerOrderHistoryRepository _repo;

        public CustomerOrderHistoryBL(ICustomerOrderHistoryRepository repo) {
            _repo = repo;
        }

        public void AddCustomerOrderHistory(CustomerOrderHistory newCustomerOrderHistory)
        {
            //TODO: Add BL
            _repo.AddCustomerOrderHistory(newCustomerOrderHistory);
        }
        public void DeleteCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BDeleted)
        {
            _repo.DeleteCustomerOrderHistory(customerOrderHistory2BDeleted);
        }
        public CustomerOrderHistory GetCustomerOrderHistoryById(int id) {
            //todo validate
            return _repo.GetCustomerOrderHistoryById(id);
        }
        public List<CustomerOrderHistory> GetCustomerOrderHistories()
        {
            //TODO Add BL
            return _repo.GetCustomerOrderHistories();
        }
        public void UpdateCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BUpdated, CustomerOrderHistory updatedDetails)
        {
            customerOrderHistory2BUpdated.LocId = updatedDetails.LocId;
            customerOrderHistory2BUpdated.CustId = updatedDetails.CustId;
            customerOrderHistory2BUpdated.OrderDate = updatedDetails.OrderDate;
            customerOrderHistory2BUpdated.OrderId = updatedDetails.OrderId;
            customerOrderHistory2BUpdated.Total = updatedDetails.Total;
            _repo.UpdateCustomerOrderHistory(customerOrderHistory2BUpdated);
        }
    }
}