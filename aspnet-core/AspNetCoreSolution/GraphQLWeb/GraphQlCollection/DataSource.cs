using GraphQLWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb.GraphQlCollection
{
    public class DataSource : IDataStore
    {
        private ApplicationDbContext _applicationDbContext;

        public DataSource(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Item GetItemByBarCode(string barCode)
        {
            return _applicationDbContext.Items.First(i => i.BarCode.Equals(barCode));
        }

        public IEnumerable<Item> GetItems()
        {
            return _applicationDbContext.Items;
        }

        public async Task<Item> AddItem(Item item)
        {
            var addedItem = await _applicationDbContext.Items.AddAsync(item);
            await _applicationDbContext.SaveChangesAsync();
            return addedItem.Entity;
        }
    }
}
