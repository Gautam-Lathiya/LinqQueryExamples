using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryExamples
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item { Id = 1, Name = "Apple", Price = 10 },
                new Item { Id = 2, Name = "Apple", Price = 20 },
                new Item { Id = 3, Name = "Banana", Price = 15 },
                new Item { Id = 4, Name = "Banana", Price = 25 },
                new Item { Id = 5, Name = "Orange", Price = 0.60m },
                new Item { Id = 6, Name = "Orange", Price = 0.65m },
                new Item { Id = 7, Name = "Milk", Price = 1.20m },
                new Item { Id = 8, Name = "Milk", Price = 1.25m },
                new Item { Id = 9, Name = "Bread", Price = 1.50m },
                new Item { Id = 10, Name = "Bread", Price = 1.55m }
            };
        }

        public static void Main(string[] args)
        {
            var items = Item.GetItems();

            var res = items.GroupBy(i => i.Name).Select(g => new
            {
                Name = g.Key,
                AveragePriceItem = g.Average(i => i.Price)
            }
                );

            foreach (var item in res)
            {
                Console.WriteLine($"Item : {item.Name} , Avg : {item.AveragePriceItem}");
            }
        }
    }

}
