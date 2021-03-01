using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface ICustomerCartMapper
    {
        Model.CustomerCart ParseCustomerCart(Entity.CustomerCart customerCart);
        Entity.CustomerCart ParseCustomerCart(Model.CustomerCart customerCart);
    }
}