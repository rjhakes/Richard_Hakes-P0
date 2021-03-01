using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class InventoryLineItemRepoDB : IInventoryLineItemRepository
    {
        private Entity.StoreDBContext _context;
        private IInventoryLineItemMapper _mapper;
        public InventoryLineItemRepoDB(Entity.StoreDBContext context, IInventoryLineItemMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.InventoryLineItem AddInventoryLineItem(Model.InventoryLineItem newInventoryLineItem)
        {
            _context.InventoryLineItems.Add(_mapper.ParseInventoryLineItem(newInventoryLineItem));
            _context.SaveChanges();
            return newInventoryLineItem;
        }

        public InventoryLineItem DeleteInventoryLineItem(InventoryLineItem inventoryLineItem2BDeleted)
        {
            _context.InventoryLineItems.Remove(_mapper.ParseInventoryLineItem(inventoryLineItem2BDeleted));
            _context.SaveChanges();
            return inventoryLineItem2BDeleted;
        }

        public InventoryLineItem GetInventoryLineItemById(int id)
        {
            return _context.InventoryLineItems
            .AsNoTracking()
            .Select(x => _mapper.ParseInventoryLineItem(x))
            .ToList()
            .FirstOrDefault(x => x.InventoryId == id);
        }

        public List<Model.InventoryLineItem> GetInventoryLineItems()
        {
            return _context.InventoryLineItems.AsNoTracking().Select(x => _mapper.ParseInventoryLineItem(x)).ToList();
        }

        public void UpdateInventoryLineItem(InventoryLineItem inventoryLineItem2BUpated)
        {
            Entity.InventoryLineItem oldInventoryLineItem = _context.InventoryLineItems.Find(inventoryLineItem2BUpated.Id);
            _context.Entry(oldInventoryLineItem).CurrentValues.SetValues(_mapper.ParseInventoryLineItem(inventoryLineItem2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}