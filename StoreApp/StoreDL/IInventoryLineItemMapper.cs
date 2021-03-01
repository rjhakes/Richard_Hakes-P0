using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    /// <summary>
    /// To parse entities from DB to models used in BL and vice versa
    /// </summary>
    public interface IInventoryLineItemMapper
    {
        Model.InventoryLineItem ParseInventoryLineItem(Entity.InventoryLineItem inventoryLineItem);
        Entity.InventoryLineItem ParseInventoryLineItem(Model.InventoryLineItem inventoryLineItem);
        
    }
}