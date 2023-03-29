using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Demo.Entities.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<GuidGraphType>("id");
            Field<StringGraphType>("name");
            Field<DecimalGraphType>("price");
        }
    }
}
