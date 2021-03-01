using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class CustomerCartMapper : ICustomerCartMapper
    {
        public Model.CustomerCart ParseCustomerCart(Entity.CustomerCart customerCart)
        {
            return new Model.CustomerCart
            {
                CustId = (int)customerCart.CustId,
                LocId = (int)customerCart.LocId,
                CurrentItemsId = (int)customerCart.CurrentItemsId,
                Id = (int)customerCart.Id
            };
        }

        public Entity.CustomerCart ParseCustomerCart(Model.CustomerCart customerCart)
        {
            if (customerCart.Id == null)
            {
                return new Entity.CustomerCart
                {
                    CustId = (int)customerCart.CustId,
                    LocId = (int)customerCart.LocId,
                    CurrentItemsId = (int)customerCart.CurrentItemsId,
                };
            }

            return new Entity.CustomerCart
            {
                CustId = (int)customerCart.CustId,
                LocId = (int)customerCart.LocId,
                CurrentItemsId = (int)customerCart.CurrentItemsId,
                Id = (int)customerCart.Id
            };
        }
    }
}