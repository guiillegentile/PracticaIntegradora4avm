using Microsoft.EntityFrameworkCore;
using PracticaIntegradora4.Data;
using PracticaIntegradora4.Entities;
using PracticaIntegradora4.Repositories.Interfaces;

namespace PracticaIntegradora4.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(p => p.Name).ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existing = GetProductById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;

                _context.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            var entityToDelete = GetProductById(product.Id);
            if (entityToDelete != null)
            {
                _context.Products.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public List<Product> SearchProductsByName(string name)
        {
            return _context.Products
                .Where(p => p.Name.Contains(name))
                .ToList();
        }
    }
}