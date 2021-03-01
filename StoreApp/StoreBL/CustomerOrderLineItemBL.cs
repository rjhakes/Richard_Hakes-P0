using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;
namespace StoreBL
{
    public class CustomerOrderLineItemBL : ICustomerOrderLineItemBL
    {
        private ICustomerOrderLineItemRepository _repo;

        public CustomerOrderLineItemBL(ICustomerOrderLineItemRepository repo) {
            _repo = repo;
        }

        public void AddCustomerOrderLineItem(CustomerOrderLineItem newCustomerOrderLineItem)
        {
            //TODO: Add BL
            _repo.AddCustomerOrderLineItem(newCustomerOrderLineItem);
        }
        public void DeleteCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BDeleted)
        {
            _repo.DeleteCustomerOrderLineItem(customerOrderLineItem2BDeleted);
        }

        public CustomerOrderLineItem GetCustomerOrderLineItemById(int id) {
            //todo validate
            return _repo.GetCustomerOrderLineItemById(id);
        }
        public CustomerOrderLineItem GetCustomerOrderLineItemById(int orderId, int prodId) {
            //todo validate
            return _repo.GetCustomerOrderLineItemById(orderId, prodId);
        }
        public List<CustomerOrderLineItem> GetCustomerOrderLineItems()
        {
            //TODO Add BL
            return _repo.GetCustomerOrderLineItems();
        }
        public void UpdateCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BUpdated, CustomerOrderLineItem updatedDetails)
        {
            customerOrderLineItem2BUpdated.OrderId = updatedDetails.OrderId;
            customerOrderLineItem2BUpdated.ProdId = updatedDetails.ProdId;
            customerOrderLineItem2BUpdated.Quantity = updatedDetails.Quantity;
            customerOrderLineItem2BUpdated.ProdPrice = updatedDetails.ProdPrice;
            _repo.UpdateCustomerOrderLineItem(customerOrderLineItem2BUpdated);
        }

        public int Ident_Curr()
        {
            return _repo.Ident_Curr();
        }
    }
}