using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IInventoryLineItemBL
    {
        List<InventoryLineItem> GetInventoryLineItems();
        void AddInventoryLineItem(InventoryLineItem newInventoryLineItem);
        InventoryLineItem GetInventoryLineItemById(int invId, int prodId);
        void DeleteInventoryLineItem(InventoryLineItem inventoryLineItem2BDeleted);
        void UpdateInventoryLineItem(InventoryLineItem inventoryLineItem2BUpdated, InventoryLineItem updatedDetails);
    }
}