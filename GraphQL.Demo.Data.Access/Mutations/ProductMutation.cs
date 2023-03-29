using GraphQL.Demo.Entities;
using GraphQL.Demo.Entities.Types;
using GraphQL.Demo.Services.Interfaces;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Access.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>("createProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    return productService.AddProduct(context.GetArgument<Product>("product")!);
                });

            Field<ProductType>("updateProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    return productService.UpdateProduct(context.GetArgument<Product>("product")!);
                });

            Field<StringGraphType>("deleteProduct", arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var productId = context.GetArgument<Guid>("id");
                    productService.DeleteProduct(productId);
                    return $"The product with Id {productId} has been deleted.";
                });
        }
    }
}
