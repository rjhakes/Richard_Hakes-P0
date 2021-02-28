using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IManagerRepository
    {
         List<Manager> GetManagers();
         Manager AddManager(Manager newManager);
         Manager GetManagerByEmail(string name);
        Manager DeleteManager(Manager manager2BDeleted);
        void UpdateManager(Manager manager2BUpdated);
    }
}