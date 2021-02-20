using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class ManagerBL : IManagerBL
    {
        private IManagerRepository _repo;

        public ManagerBL(IManagerRepository repo) {
            _repo = repo;
        }

        public void AddManager(Manager newManager)
        {
            //TODO: Add BL
            _repo.AddManager(newManager);
        }
        public List<Manager> GetManagers()
        {
            //TODO Add BL
            return _repo.GetManagers();
        }
    }
}
