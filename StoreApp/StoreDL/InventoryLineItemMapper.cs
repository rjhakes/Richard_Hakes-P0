using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class InventoryLineItemMapper : IInventoryLineItemMapper
    {
        public Model.InventoryLineItem ParseInventoryLineItem(Entity.InventoryLineItem inventoryLineItem)
        {
            return new Model.InventoryLineItem
            {
                InventoryId = inventoryLineItem.InventoryId,
                ProductId = inventoryLineItem.ProductId,
                Quantity = inventoryLineItem.Quantity,
                Id = inventoryLineItem.Id
            };
        }

        public Entity.InventoryLineItem ParseInventoryLineItem(Model.InventoryLineItem inventoryLineItem)
        {
            if (inventoryLineItem.Id == null)
            {
                return new Entity.InventoryLineItem
                {
                    InventoryId = inventoryLineItem.InventoryId,
                    ProductId = inventoryLineItem.ProductId,
                    Quantity = inventoryLineItem.Quantity,
                };
            }

            return new Entity.InventoryLineItem
            {
                InventoryId = inventoryLineItem.InventoryId,
                ProductId = inventoryLineItem.ProductId,
                Quantity = inventoryLineItem.Quantity,
                Id = (int)inventoryLineItem.Id
            };
        }
    }
}