using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Calculator
    {
        private static int Add(int n, int m)
        {
            return n + m;
        }
        public static async Task<int> AddAsync(int n, int m)
        {
            int val = await Task.Run(() => Add(n, m));
            return val;
        }
    }
}
