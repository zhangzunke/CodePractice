using GraphQL.Types;
using GraphQLWeb.GraphQlCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb
{
    public class InventoryMutation : ObjectGraphType
    {
        public InventoryMutation(IDataStore dataSource)
        {
            Field<ItemType>(
                "createItem",
                arguments: new QueryArguments(
                      new QueryArgument<NonNullGraphType<ItemInputType>> { Name = "item"}
                    ),
                resolve: context => 
                {
                    var item = context.GetArgument<Item>("item");
                    return dataSource.AddItem(item);
                });
        }
    }
}
