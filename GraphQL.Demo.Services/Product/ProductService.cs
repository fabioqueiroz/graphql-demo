using GraphQL.Demo.Data.Interfaces;
using GraphQL.Demo.Entities;
using GraphQL.Demo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Services.Product
{
    using Product = Entities.Product;
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetAllProductsAsync(cancellationToken);
        }

        public async Task<Product> GetProductByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetProductByIdAsync(id, cancellationToken);
        }

        public async Task<Product> AddProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            if (await _productRepository.NameExistsAsync(product.Name, cancellationToken))
            {
                throw new Exception($"Name {product.Name} already exists");
            }

            return await _productRepository.AddProductAsync(product, cancellationToken);
        }

        public async Task<Product> UpdateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            if (await _productRepository.NameExistsAsync(product.Name, cancellationToken))
            {
                throw new Exception($"Name {product.Name} already exists");
            }

            return await _productRepository.UpdateProductAsync(product, cancellationToken);
        }

        public async Task DeleteProductAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _productRepository.DeleteProductAsync(id, cancellationToken);
        }
    }
}
