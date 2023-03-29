using GraphQL.Demo.Data.Interfaces;
using GraphQL.Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products.SingleAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Add(product);
            await CommitAsync(cancellationToken);
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            var productToUpdate = await _context.Products.SingleAsync(p => p.Id ==  product.Id, cancellationToken);
            _context.Products.Update(productToUpdate);
            await CommitAsync(cancellationToken);
            return product;
        }

        public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken)
        {
            var productToRemove = await _context.Products.SingleAsync(p => p.Id == id, cancellationToken);
            _context.Products.Remove(productToRemove);
            await CommitAsync(cancellationToken);
        }

        public async Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Products.AnyAsync(p => p.Name == name, cancellationToken);
        }
    }
}
