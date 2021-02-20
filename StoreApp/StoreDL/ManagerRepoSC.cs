using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class ManagerRepoSC : IManagerRepository
    {
        public List<Manager> GetManagers()
        {
            return Storage.AllManagers;
        }
        public Manager AddManager(Manager newManager)
        {
            Storage.AllManagers.Add(newManager);
            return newManager;
        }
    }
}