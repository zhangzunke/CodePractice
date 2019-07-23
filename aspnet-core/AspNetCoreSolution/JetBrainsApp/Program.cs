using System;
using JetBrains.Annotations;
namespace JetBrainsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = HelloWord(null);
            Console.WriteLine("Hello World!");
        }
        static string HelloWord([NotNull]string name)
        {
            return $"Hello, {name}";
        }
    }
}
