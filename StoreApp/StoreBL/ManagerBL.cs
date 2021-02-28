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
        
        public void DeleteManager(Manager manager2BDeleted)
        {
            _repo.DeleteManager(manager2BDeleted);
        }
        public Manager GetManagerByEmail(string name) {
            //todo validate
            return _repo.GetManagerByEmail(name);
        }
        public List<Manager> GetManagers()
        {
            //TODO Add BL
            return _repo.GetManagers();
        }
        public void UpdateManager(Manager manager2BUpdated, Manager updatedDetails)
        {
            manager2BUpdated.ManagerName = updatedDetails.ManagerName;
            manager2BUpdated.ManagerEmail = updatedDetails.ManagerEmail;
            manager2BUpdated.ManagerPasswordHash = updatedDetails.ManagerPasswordHash;
            manager2BUpdated.ManagerPhone = updatedDetails.ManagerPhone;
            manager2BUpdated.ManagerLocId = updatedDetails.ManagerLocId;

            _repo.UpdateManager(manager2BUpdated);
        }
    }
}
