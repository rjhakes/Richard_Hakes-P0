using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IManagerBL
    {
        List<Manager> GetManagers();
        void AddManager(Manager newManager);
        Manager GetManagerByEmail(string name);
        void DeleteManager(Manager manager2BDeleted);
        void UpdateManager(Manager manager2BUpdated, Manager updatedDetails);
    }
}