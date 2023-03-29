using GraphQL.Demo.Data.Access.Mutations;
using GraphQL.Demo.Data.Access.Queries;
using GraphQL.Demo.Data.Access.Schema;
using GraphQL.Demo.Entities.Types;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Data.Access
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddGraphQLServices(this IServiceCollection services) 
        {
            services.AddSingleton<ProductType>();
            services.AddSingleton<ProductQuery>();
            services.AddSingleton<ProductMutation>();
            services.AddSingleton<ISchema, ProductSchema>();

            return services;
        }
    }
}
