using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConcurrentDemo
{
    class Program
    {
        private static ConcurrentQueue<Product> _Products { get; set; }

        static void Main(string[] args)
        {
            //NewMethod();
            int count = 0;
            var queue = new ConcurrentQueue<string>();
            Task.Factory.StartNew(() => 
            {
                while (true)
                {
                    queue.Enqueue("value" + count);
                    count++;
                }
            });

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    string value;
                    if (queue.TryDequeue(out value))
                    {
                        Console.WriteLine("Worker 1: " + value);
                    }
                }
            });

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    string value;
                    if (queue.TryDequeue(out value))
                    {
                        Console.WriteLine("Worker 2: " + value);
                    }

                }
            });

            Console.ReadLine();
        }

        private static void NewMethod()
        {
            _Products = new ConcurrentQueue<Product>();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Task t1 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            Task t2 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            Task t3 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            Task.WaitAll(t1, t2, t3);
            watch.Stop();
            Console.WriteLine(_Products.Count);
            Console.WriteLine(watch.ElapsedMilliseconds);
        }

        static void AddProducts()
        {
            Parallel.For(0, 1000000, (i) =>
            {
                Product product = new Product();
                product.Name = "name" + i;
                product.Category = "category" + i;
                product.SellPrice = i;
                _Products.Enqueue(product);
            });
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int SellPrice { get; set; }
    }
}
