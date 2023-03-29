using GraphQL.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken);
        Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken);
        Task DeleteProductAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken);
    }
}
