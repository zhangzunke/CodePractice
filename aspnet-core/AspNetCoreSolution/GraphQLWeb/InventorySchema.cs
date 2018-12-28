using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb
{
    public class InventorySchema : Schema
    {
        public InventorySchema(InventoryQuery query, InventoryMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
