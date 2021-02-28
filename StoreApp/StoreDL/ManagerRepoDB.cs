using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class ManagerRepoDB :IManagerRepository
    {
        private Entity.StoreDBContext _context;
        private IManagerMapper _mapper;
        public ManagerRepoDB(Entity.StoreDBContext context, IManagerMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Manager AddManager(Model.Manager newManager)
        {
            _context.Managers.Add(_mapper.ParseManager(newManager));
            _context.SaveChanges();
            return newManager;
        }

        public Manager DeleteManager(Manager manager2BDeleted)
        {
            _context.Managers.Remove(_mapper.ParseManager(manager2BDeleted));
            _context.SaveChanges();
            return manager2BDeleted;
        }

        public Manager GetManagerByEmail(string name)
        {
            return _context.Managers
            .AsNoTracking()
            .Select(x => _mapper.ParseManager(x))
            .ToList()
            .FirstOrDefault(x => x.ManagerEmail == name);
        }

        public List<Model.Manager> GetManagers()
        {
            return _context.Managers.AsNoTracking().Select(x => _mapper.ParseManager(x)).ToList();
        }

        public void UpdateManager(Manager manager2BUpated)
        {
            Entity.Manager oldManager = _context.Managers.Find(manager2BUpated.Id);
            _context.Entry(oldManager).CurrentValues.SetValues(_mapper.ParseManager(manager2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}