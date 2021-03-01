using Model = StoreModels;
using Entity = StoreDL.Entities;
namespace StoreDL
{
    /// <summary>
    /// To parse entities from DB to models used in BL and vice versa
    /// </summary>
    public interface IProductMapper
    {
        Model.Product ParseProduct(Entity.Product product);
        Entity.Product ParseProduct(Model.Product product);
        
    }
}