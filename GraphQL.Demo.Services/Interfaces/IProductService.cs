using GraphQL.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Services.Interfaces
{
    using Product = Entities.Product;
    public interface IProductService
    {
        //IEnumerable<Product> GetAllProducts();
        //Product GetProductById(Guid id);
        //Product AddProduct(Product product);
        //Product UpdateProduct(Product product);
        //void DeleteProduct(Guid id);

        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
