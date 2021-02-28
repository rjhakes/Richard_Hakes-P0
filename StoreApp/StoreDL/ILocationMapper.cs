using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    public interface ILocationMapper
    {
        Model.Location ParseLocation(Entity.Location location);
        Entity.Location ParseLocation(Model.Location location);
    }
}