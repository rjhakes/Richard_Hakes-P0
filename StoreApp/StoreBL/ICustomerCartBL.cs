using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface ICustomerCartBL
    {
        List<CustomerCart> GetCustomerCarts();
        void AddCustomerCart(CustomerCart newCustomerCart);
        CustomerCart GetCustomerCartByIds(int customerId, int locId);
        void DeleteCustomerCart(CustomerCart customerCart2BDeleted);
        void UpdateCustomerCart(CustomerCart customerCart2BUpdated, CustomerCart updatedDetails);
    }
}