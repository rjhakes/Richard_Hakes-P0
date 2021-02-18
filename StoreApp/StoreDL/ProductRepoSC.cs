using StoreModels;
using System.Collections.Generic;

namespace StoreDL
{
    public class ProductRepoSC : IProductRepository
    {
        public List<Product> GetProducts()
        {
            return Storage.AllProducts;
        }
        public Product AddProduct(Product newProduct)
        {
            Storage.AllProducts.Add(newProduct);
            return newProduct;
        }
    }
}