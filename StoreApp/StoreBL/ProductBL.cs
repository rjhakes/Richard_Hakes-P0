using System;
using System.Collections.Generic;
using StoreDL;
using StoreModels;

namespace StoreBL
{
    public class ProductBL : IProductBL
    {
        private IProductRepository _repo;

        public ProductBL(IProductRepository repo) {
            _repo = repo;
        }

        public void AddProduct(Product newProduct)
        {
            //TODO: Add BL
            _repo.AddProduct(newProduct);
        }
        public void DeleteProduct(Product product2BDeleted)
        {
            _repo.DeleteProduct(product2BDeleted);
        }
        public Product GetProductByName(string name) {
            //todo validate
            return _repo.GetProductByName(name);
        }
        public Product GetProductById(int id) {
            //todo validate
            return _repo.GetProductById(id);
        }
        public List<Product> GetProducts()
        {
            //TODO Add BL
            return _repo.GetProducts();
        }
        public void UpdateProduct(Product product2BUpdated, Product updatedDetails)
        {
            product2BUpdated.ProdName = updatedDetails.ProdName;
            product2BUpdated.ProdPrice = updatedDetails.ProdPrice;
            product2BUpdated.ProdCategory = updatedDetails.ProdCategory;
            product2BUpdated.ProdBrandName = updatedDetails.ProdBrandName;
            _repo.UpdateProduct(product2BUpdated);
        }
    }
}
