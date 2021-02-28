using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface IManagerMapper
    {
        StoreModels.Manager ParseManager(Entity.Manager manager);
        Entity.Manager ParseManager(Model.Manager manager);
    }
}