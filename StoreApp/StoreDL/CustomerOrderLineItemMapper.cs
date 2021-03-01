using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class CustomerOrderLineItemMapper : ICustomerOrderLineItemMapper
    {
        public Model.CustomerOrderLineItem ParseCustomerOrderLineItem(Entity.CustomerOrderLineItem customerOrderLineItem)
        {
            return new Model.CustomerOrderLineItem
            {
                OrderId = customerOrderLineItem.OrderId,
                ProdId = customerOrderLineItem.ProdId,
                Quantity = customerOrderLineItem.Quantity,
                ProdPrice = customerOrderLineItem.ProdPrice,
                Id = customerOrderLineItem.Id
            };
        }

        public Entity.CustomerOrderLineItem ParseCustomerOrderLineItem(Model.CustomerOrderLineItem customerOrderLineItem)
        {
            if (customerOrderLineItem.Id == null)
            {
                return new Entity.CustomerOrderLineItem
                {
                    OrderId = customerOrderLineItem.OrderId,
                    ProdId = customerOrderLineItem.ProdId,
                    Quantity = customerOrderLineItem.Quantity,
                    ProdPrice = customerOrderLineItem.ProdPrice,
                };
            }

            return new Entity.CustomerOrderLineItem
            {
                OrderId = customerOrderLineItem.OrderId,
                ProdId = customerOrderLineItem.ProdId,
                Quantity = customerOrderLineItem.Quantity,
                ProdPrice = customerOrderLineItem.ProdPrice,
                Id = (int)customerOrderLineItem.Id
            };
        }
    }
}