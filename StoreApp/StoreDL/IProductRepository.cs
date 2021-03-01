using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product AddProduct(Product newProduct);
        Product GetProductByName(string name);
        Product GetProductById(int id);
        Product DeleteProduct(Product product2BDeleted);
        void UpdateProduct(Product product2BUpdated);
    }
}