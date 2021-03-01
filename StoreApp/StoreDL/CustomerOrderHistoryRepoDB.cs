using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class CustomerOrderHistoryRepoDB : ICustomerOrderHistoryRepository
    {
        private Entity.StoreDBContext _context;
        private ICustomerOrderHistoryMapper _mapper;
        public CustomerOrderHistoryRepoDB(Entity.StoreDBContext context, ICustomerOrderHistoryMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.CustomerOrderHistory AddCustomerOrderHistory(Model.CustomerOrderHistory newCustomerOrderHistory)
        {
            _context.CustomerOrderHistories.Add(_mapper.ParseCustomerOrderHistory(newCustomerOrderHistory));
            _context.SaveChanges();
            return newCustomerOrderHistory;
        }

        public CustomerOrderHistory DeleteCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BDeleted)
        {
            _context.CustomerOrderHistories.Remove(_mapper.ParseCustomerOrderHistory(customerOrderHistory2BDeleted));
            _context.SaveChanges();
            return customerOrderHistory2BDeleted;
        }

        public CustomerOrderHistory GetCustomerOrderHistoryById(int id)
        {
            return _context.CustomerOrderHistories
            .AsNoTracking()
            .Select(x => _mapper.ParseCustomerOrderHistory(x))
            .ToList()
            .FirstOrDefault(x => x.OrderId == id);
        }

        public List<Model.CustomerOrderHistory> GetCustomerOrderHistories()
        {
            return _context.CustomerOrderHistories.AsNoTracking().Select(x => _mapper.ParseCustomerOrderHistory(x)).ToList();
        }

        public void UpdateCustomerOrderHistory(CustomerOrderHistory customerOrderHistory2BUpated)
        {
            Entity.CustomerOrderHistory oldCustomerOrderHistory = _context.CustomerOrderHistories.Find(customerOrderHistory2BUpated.Id);
            _context.Entry(oldCustomerOrderHistory).CurrentValues.SetValues(_mapper.ParseCustomerOrderHistory(customerOrderHistory2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}