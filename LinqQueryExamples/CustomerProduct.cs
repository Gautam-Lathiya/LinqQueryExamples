using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueryExamples
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "John",
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane",
                }
            };
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product1",
                    Price = 10
                },
                new Product
                {
                    Id = 2,
                    Name = "Product2",
                    Price = 20
                },
                new Product
                {
                    Id = 3,
                    Name = "Product3",
                    Price = 30
                }
            };
        }
    }

    public class Order
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    CustomerId = 1,
                    ProductId = 1
                },
                new Order
                {
                    CustomerId = 1,
                    ProductId = 2
                },
                new Order
                {
                    CustomerId = 2,
                    ProductId = 2
                },
                new Order
                {
                    CustomerId = 2,
                    ProductId = 3
                }
            };
        }
    }


    public class CustomerProduct
    {
        public static void Main(string[] args)
        {
            var customers = Customer.GetCustomers();
            var products = Product.GetProducts();
            var orders = new Order().GetOrders();
            var result = orders.GroupBy(o => o.CustomerId).
                         Select(g => new
                         {
                             CustomerName = customers.First(c=>c.Id == g.Key).Name,
                             Total = g.Sum(o => products.First(p => p.Id == o.ProductId).Price)
                         });
            foreach (var item in result)
            {
                Console.WriteLine($"Customer: {item.CustomerName}, Amount: {item.Total}");
            }
        }   
    }

}
