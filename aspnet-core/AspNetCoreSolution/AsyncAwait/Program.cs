using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Task<int> t = Calculator.AddAsync(1, 2);
            Console.WriteLine($"Result: {t.Result}");

            var download = new Download();
            var result = download.CountCharacters(1, "http://www.cnblogs.com/");
            var s = string.Empty;
            for (int i = 0; i < 600; i++)
            {
                s = s + i;
            }
            var length = result.Result;
            Console.Read();
        }
    }
}
