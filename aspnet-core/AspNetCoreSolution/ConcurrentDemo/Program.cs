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
        //BlockingCollection
        static void Main(string[] args)
        {
            //NewMethod();
            //NewMethod1();
            var list = new List<decimal>();
            for (int i = 1; i <= 5; i++)
            {
                list.Add(i);
            }
            var s = Percentile(list.ToArray(), 0.95M);
            Console.ReadLine();
        }

        private static void NewMethod1()
        {
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
        }

        public static decimal Percentile(decimal[] sequence, decimal excelPercentile)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            decimal n = (N - 1) * excelPercentile + 1;
            // Another method: double n = (N + 1) * excelPercentile;
            if (n == 1M) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                decimal d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
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
