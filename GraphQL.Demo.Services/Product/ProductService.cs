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

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProductsAsync(new CancellationToken());
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id, new CancellationToken());
        }

        public async Task<Product> AddProduct(Product product)
        {
            if (await _productRepository.NameExistsAsync(product.Name, new CancellationToken()))
            {
                throw new Exception($"Name {product.Name} already exists");
            }

            return await _productRepository.AddProductAsync(product, new CancellationToken());
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            if (await _productRepository.NameExistsAsync(product.Name, new CancellationToken()))
            {
                throw new Exception($"Name {product.Name} already exists");
            }

            return await _productRepository.UpdateProductAsync(product, new CancellationToken());
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.DeleteProductAsync(id, new CancellationToken());
        }
    }
}
