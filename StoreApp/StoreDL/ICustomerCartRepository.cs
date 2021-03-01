using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface ICustomerCartRepository
    {
        List<CustomerCart> GetCustomerCarts();
        CustomerCart AddCustomerCart(CustomerCart newCustomerCart);
        CustomerCart GetCustomerCartByIds(int customerId, int locId);
        CustomerCart DeleteCustomerCart(CustomerCart customerCart2BDeleted);
        void UpdateCustomerCart(CustomerCart customerCart2BUpdated);
    }
}