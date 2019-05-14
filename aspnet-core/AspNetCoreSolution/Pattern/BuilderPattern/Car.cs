using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Pattern.BuilderPattern
{
    public class Car
    {
        private IList<string> parts = new List<string>();

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            WriteLine("Beginning to build car...");
            foreach (var part in parts)
            {
                WriteLine($"Part: {part} has been installed");
            }
            WriteLine("The car has been build");
        }
    }
}
