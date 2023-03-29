using GraphQL.Demo.Entities.Types;
using GraphQL.Demo.Services.Interfaces;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Access.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });

            Field<ProductType>("product", arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id"}),
                resolve: context => 
                { 
                    return productService.GetProductById(context.GetArgument<Guid>("id"));
                });
        }
    }
}
