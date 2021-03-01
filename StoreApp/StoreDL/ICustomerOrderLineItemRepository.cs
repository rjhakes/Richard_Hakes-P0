using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerOrderLineItemRepository
    {
        List<CustomerOrderLineItem> GetCustomerOrderLineItems();
        CustomerOrderLineItem AddCustomerOrderLineItem(CustomerOrderLineItem newCustomerOrderLineItem);
        CustomerOrderLineItem GetCustomerOrderLineItemById(int id);
        CustomerOrderLineItem GetCustomerOrderLineItemById(int orderId, int prodId);
        CustomerOrderLineItem DeleteCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BDeleted);
        void UpdateCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BUpdated);
        int Ident_Curr();
    }
}