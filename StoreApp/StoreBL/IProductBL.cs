using StoreModels;
using System.Collections.Generic;

namespace StoreBL
{
    public interface IProductBL
    {
        List<Product> GetProducts();
        void AddProduct(Product newProduct);
        Product GetProductByName(string name);
        Product GetProductById(int id);
        void DeleteProduct(Product product2BDeleted);
        void UpdateProduct(Product product2BUpdated, Product updatedDetails);
    }
}