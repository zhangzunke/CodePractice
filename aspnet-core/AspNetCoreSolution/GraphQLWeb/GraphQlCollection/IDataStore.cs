using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb.GraphQlCollection
{
    public interface IDataStore
    {
        IEnumerable<Item> GetItems();
        Item GetItemByBarCode(string barCode);
    }
}
