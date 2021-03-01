using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface ICustomerOrderLineItemMapper
    {
        Model.CustomerOrderLineItem ParseCustomerOrderLineItem(Entity.CustomerOrderLineItem customerOrderLineItem);
        Entity.CustomerOrderLineItem ParseCustomerOrderLineItem(Model.CustomerOrderLineItem customerOrderLineItem);
    }
}