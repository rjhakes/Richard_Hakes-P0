using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class ProductRepoDB : IProductRepository
    {
        private Entity.StoreDBContext _context;
        private IProductMapper _mapper;
        public ProductRepoDB(Entity.StoreDBContext context, IProductMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Product AddProduct(Model.Product newProduct)
        {
            _context.Products.Add(_mapper.ParseProduct(newProduct));
            _context.SaveChanges();
            return newProduct;
        }

        public Product DeleteProduct(Product product2BDeleted)
        {
            _context.Products.Remove(_mapper.ParseProduct(product2BDeleted));
            _context.SaveChanges();
            return product2BDeleted;
        }

        public Product GetProductByName(string name)
        {
            return _context.Products
            .AsNoTracking()
            .Select(x => _mapper.ParseProduct(x))
            .ToList()
            .FirstOrDefault(x => x.ProdName == name);
        }
        public Product GetProductById(int id)
        {
            return _context.Products
            .AsNoTracking()
            .Select(x => _mapper.ParseProduct(x))
            .ToList()
            .FirstOrDefault(x => x.Id == id);
        }
        public List<Model.Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList();
        }

        public void UpdateProduct(Product product2BUpated)
        {
            Entity.Product oldProduct = _context.Products.Find(product2BUpated.Id);
            _context.Entry(oldProduct).CurrentValues.SetValues(_mapper.ParseProduct(product2BUpated));

            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
    }
}