using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class ManagerMapper : IManagerMapper
    {
        public Model.Manager ParseManager(Entity.Manager manager)
        {
            return new Model.Manager
            {
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPasswordHash = manager.ManagerPasswordHash,
                ManagerPhone = manager.ManagerPhone,
                ManagerLocId = (int)manager.ManagerLocId,
                Id = manager.Id
            };
        }

        public Entity.Manager ParseManager(Model.Manager manager)
        {
            if (manager.Id == null)
            {
                return new Entity.Manager
                {
                    ManagerName = manager.ManagerName,
                    ManagerEmail = manager.ManagerEmail,
                    ManagerPasswordHash = manager.ManagerPasswordHash,
                    ManagerPhone = manager.ManagerPhone,
                    ManagerLocId = (int)manager.ManagerLocId,
                };
            }
            return new Entity.Manager
            {
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPasswordHash = manager.ManagerPasswordHash,
                ManagerPhone = manager.ManagerPhone,
                ManagerLocId = (int)manager.ManagerLocId,
                Id = (int)manager.Id
            };
        }
    }
}