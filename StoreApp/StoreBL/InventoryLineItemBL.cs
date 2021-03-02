using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class InventoryLineItemBL : IInventoryLineItemBL
    {
        private IInventoryLineItemRepository _repo;

        public InventoryLineItemBL(IInventoryLineItemRepository repo) {
            _repo = repo;
        }

        public void AddInventoryLineItem(InventoryLineItem newInventoryLineItem)
        {
            //TODO: Add BL
            _repo.AddInventoryLineItem(newInventoryLineItem);
        }
        public void DeleteInventoryLineItem(InventoryLineItem inventoryLineItem2BDeleted)
        {
            _repo.DeleteInventoryLineItem(inventoryLineItem2BDeleted);
        }
        public InventoryLineItem GetInventoryLineItemById(int invId, int prodId) {
            //todo validate
            return _repo.GetInventoryLineItemById(invId, prodId);
        }
        public List<InventoryLineItem> GetInventoryLineItems()
        {
            //TODO Add BL
            return _repo.GetInventoryLineItems();
        }
        public void UpdateInventoryLineItem(InventoryLineItem inventoryLineItem2BUpdated, InventoryLineItem updatedDetails)
        {
            inventoryLineItem2BUpdated.InventoryId = updatedDetails.InventoryId;
            inventoryLineItem2BUpdated.ProductId = updatedDetails.ProductId;
            inventoryLineItem2BUpdated.Quantity = updatedDetails.Quantity;
            _repo.UpdateInventoryLineItem(inventoryLineItem2BUpdated);
        }

        
    }
}