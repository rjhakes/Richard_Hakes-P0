using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IInventoryLineItemRepository
    {
        List<InventoryLineItem> GetInventoryLineItems();
        InventoryLineItem AddInventoryLineItem(InventoryLineItem newInventoryLineItem);
        InventoryLineItem GetInventoryLineItemById(int invId, int prodId);
        InventoryLineItem DeleteInventoryLineItem(InventoryLineItem inventoryLineItem2BDeleted);
        void UpdateInventoryLineItem(InventoryLineItem inventoryLineItem2BUpdated);
    }
}