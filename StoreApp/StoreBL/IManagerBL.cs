using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IManagerBL
    {
        List<Manager> GetManagers();
         void AddManager(Manager newManager);
    }
}