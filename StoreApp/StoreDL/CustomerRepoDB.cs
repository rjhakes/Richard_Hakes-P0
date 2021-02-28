using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class CustomerRepoDB : ICustomerRepository
    {
        private Entity.StoreDBContext _context;
        private ICustomerMapper _mapper;
        public CustomerRepoDB(Entity.StoreDBContext context, ICustomerMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            _context.Customers.Remove(_mapper.ParseCustomer(customer2BDeleted));
            _context.SaveChanges();
            return customer2BDeleted;
        }

        public Customer GetCustomerByEmail(string name)
        {
            return _context.Customers
            .AsNoTracking()
            .Select(x => _mapper.ParseCustomer(x))
            .ToList()
            .FirstOrDefault(x => x.CustomerEmail == name);
        }

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public void UpdateCustomer(Customer customer2BUpated)
        {
            Entity.Customer oldCustomer = _context.Customers.Find(customer2BUpated.Id);
            _context.Entry(oldCustomer).CurrentValues.SetValues(_mapper.ParseCustomer(customer2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}