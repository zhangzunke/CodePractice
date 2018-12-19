using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLWeb.GraphQlCollection;

namespace GraphQLWeb
{
    public class HelloWorldQuery : ObjectGraphType
    {
        public HelloWorldQuery()
        {
            Field<StringGraphType>(
                name: "hello",
                resolve: context => "world"
            );

            Field<StringGraphType>(
                name: "howdy",
                resolve: context => "universe"
            );

            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> {  Name = "barCode"}),
                resolve: context => 
                {
                    var barCode = context.GetArgument<string>("barCode");
                    return new DataSource().GetItemByBarcode(barCode);
                }
            );
        }
    }
}
