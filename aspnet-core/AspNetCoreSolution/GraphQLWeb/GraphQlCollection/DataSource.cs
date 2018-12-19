using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLWeb.GraphQlCollection
{
    public class DataSource
    {
        public IList<Item> Items
        {
            get;
            set;
        }

        public DataSource()
        {
            Items = new List<Item>()
            {
                new Item { BarCode= "123", Title="Headphone", SellingPrice=50},
                new Item { BarCode= "456", Title="Keyboard", SellingPrice= 40},
                new Item { BarCode= "789", Title="Monitor", SellingPrice= 100}
            };
        }

        public Item GetItemByBarcode(string barcode)
        {
            return Items.First(i => i.BarCode.Equals(barcode));
        }
    }
}
