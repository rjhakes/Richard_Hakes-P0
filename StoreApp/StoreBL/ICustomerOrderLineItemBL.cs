using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ICustomerOrderLineItemBL
    {
        List<CustomerOrderLineItem> GetCustomerOrderLineItems();
        void AddCustomerOrderLineItem(CustomerOrderLineItem newCustomerOrderLineItem);

        CustomerOrderLineItem GetCustomerOrderLineItemById(int id);
        CustomerOrderLineItem GetCustomerOrderLineItemById(int orderId, int prodId);
        void DeleteCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BDeleted);
        void UpdateCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BUpdated, CustomerOrderLineItem updatedDetails);
        int Ident_Curr();
    }
}