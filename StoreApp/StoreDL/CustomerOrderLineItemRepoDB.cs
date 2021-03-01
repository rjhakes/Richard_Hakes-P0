using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class CustomerOrderLineItemRepoDB : ICustomerOrderLineItemRepository
    {
        private Entity.StoreDBContext _context;
        private ICustomerOrderLineItemMapper _mapper;
        public CustomerOrderLineItemRepoDB(Entity.StoreDBContext context, ICustomerOrderLineItemMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.CustomerOrderLineItem AddCustomerOrderLineItem(Model.CustomerOrderLineItem newCustomerOrderLineItem)
        {
            _context.CustomerOrderLineItems.Add(_mapper.ParseCustomerOrderLineItem(newCustomerOrderLineItem));
            _context.SaveChanges();
            return newCustomerOrderLineItem;
        }

        public CustomerOrderLineItem DeleteCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BDeleted)
        {
            _context.CustomerOrderLineItems.Remove(_mapper.ParseCustomerOrderLineItem(customerOrderLineItem2BDeleted));
            _context.SaveChanges();
            return customerOrderLineItem2BDeleted;
        }

        public CustomerOrderLineItem GetCustomerOrderLineItemById(int id)
        {
            return _context.CustomerOrderLineItems
            .AsNoTracking()
            .Select(x => _mapper.ParseCustomerOrderLineItem(x))
            .ToList()
            .FirstOrDefault(x => x.Id == id);
        }
        public CustomerOrderLineItem GetCustomerOrderLineItemById(int orderId, int prodId)
        {
            return _context.CustomerOrderLineItems
            .AsNoTracking()
            .Select(x => _mapper.ParseCustomerOrderLineItem(x))
            .ToList()
            .FirstOrDefault(x => x.OrderId == orderId && x.ProdId == prodId);
        }

        public List<Model.CustomerOrderLineItem> GetCustomerOrderLineItems()
        {
            return _context.CustomerOrderLineItems.AsNoTracking().Select(x => _mapper.ParseCustomerOrderLineItem(x)).ToList();
        }

        public void UpdateCustomerOrderLineItem(CustomerOrderLineItem customerOrderLineItem2BUpated)
        {
            Entity.CustomerOrderLineItem oldCustomerOrderLineItem = _context.CustomerOrderLineItems.Find(customerOrderLineItem2BUpated.Id);
            _context.Entry(oldCustomerOrderLineItem).CurrentValues.SetValues(_mapper.ParseCustomerOrderLineItem(customerOrderLineItem2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        public int Ident_Curr()
        {
            //int? intIdt = _context.CustomerOrderLineItems.Max()
            return _context.CustomerOrderLineItems.Max(x => (int)x.Id);
        }
    }
}