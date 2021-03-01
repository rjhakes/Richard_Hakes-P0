using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class CustomerCartRepoDB : ICustomerCartRepository
    {
        private Entity.StoreDBContext _context;
        private ICustomerCartMapper _mapper;
        public CustomerCartRepoDB(Entity.StoreDBContext context, ICustomerCartMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.CustomerCart AddCustomerCart(Model.CustomerCart newCustomerCart)
        {
            _context.CustomerCarts.Add(_mapper.ParseCustomerCart(newCustomerCart));
            _context.SaveChanges();
            return newCustomerCart;
        }

        public CustomerCart DeleteCustomerCart(CustomerCart customerCart2BDeleted)
        {
            _context.CustomerCarts.Remove(_mapper.ParseCustomerCart(customerCart2BDeleted));
            _context.SaveChanges();
            return customerCart2BDeleted;
        }

        public CustomerCart GetCustomerCartByIds(int customerId, int locId)
        {
            return _context.CustomerCarts
            .AsNoTracking()
            .Select(x => _mapper.ParseCustomerCart(x))
            .ToList()
            .FirstOrDefault(x => x.CustId == customerId && x.LocId == locId);
        }

        public List<Model.CustomerCart> GetCustomerCarts()
        {
            return _context.CustomerCarts.AsNoTracking().Select(x => _mapper.ParseCustomerCart(x)).ToList();
        }

        public void UpdateCustomerCart(CustomerCart customerCart2BUpated)
        {
            Entity.CustomerCart oldCustomerCart = _context.CustomerCarts.Find(customerCart2BUpated.Id);
            _context.Entry(oldCustomerCart).CurrentValues.SetValues(_mapper.ParseCustomerCart(customerCart2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        
    }
}