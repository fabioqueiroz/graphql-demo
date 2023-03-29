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
        //private static List<Product> _products = new()
        //{
        //    new Product { Id = Guid.Parse("d2c5f314-6c97-48e8-9c35-b0de98503526"), Name = "Product 1", Price = 12.32M },
        //    new Product { Id = Guid.Parse("7d7f63b6-e3d9-49be-a9c6-4fb434f4e5b5"), Name = "Product 2", Price = 25.48M },
        //    new Product { Id = Guid.Parse("4c316593-f78f-4fdd-ade0-da9a78e0c139"), Name = "Product 3", Price = 36.66M }
        //};

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

        #region Demo
        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _products;
        //}

        //public Product GetProductById(Guid id)
        //{
        //    return _products.Single(p => p.Id == id);
        //}

        //public Product AddProduct(Product product)
        //{
        //    _products.Add(product);
        //    return product;
        //}

        //public Product UpdateProduct(Product product)
        //{
        //    var productInDb = _products.Single(p => p.Id == product.Id);
        //    productInDb.Update(product.Name, product.Price);
        //    return productInDb;
        //}

        //public void DeleteProduct(Guid id)
        //{
        //    var productInDb = _products.Single(p => p.Id == id);
        //    _products.Remove(productInDb);
        //}
        #endregion


    }
}
