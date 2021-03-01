using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL.Entities;
namespace StoreDL
{
    public class ProductMapper : IProductMapper
    {
        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product
            {
                ProdName = product.ProdName,
                ProdPrice = product.ProdPrice,
                ProdCategory = (Model.Category)product.ProdCategory,
                ProdBrandName = product.ProdBrandName,
                Id = product.Id
            };
        }

        public Entity.Product ParseProduct(Model.Product product)
        {
            if (product.Id == null)
            {
                return new Entity.Product
                {
                    ProdName = product.ProdName,
                    ProdPrice = product.ProdPrice,
                    ProdCategory = (int)product.ProdCategory,
                    ProdBrandName = product.ProdBrandName,
                };
            }

            return new Entity.Product
            {
                ProdName = product.ProdName,
                ProdPrice = product.ProdPrice,
                ProdCategory = (int)product.ProdCategory,
                ProdBrandName = product.ProdBrandName,
                Id = (int)product.Id
            };
        }
    }
}