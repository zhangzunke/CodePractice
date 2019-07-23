using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Download
    {
        public async Task<int> CountCharacters(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"id: {id}, {address} start:");

            var result = await wc.DownloadStringTaskAsync(address);

            Console.WriteLine($"id: {id}, {address} end:");
            return result.Length;
        }
    }
}
