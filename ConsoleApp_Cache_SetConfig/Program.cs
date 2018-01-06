using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Cache_SetConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===ConsoleApp_Cache_SetConfig===");
            ObjectCache cache2 = MemoryCache.Default;
            var physicalMemoryLimit = (cache2 as MemoryCache).PhysicalMemoryLimit;
            Console.WriteLine("physicalMemoryLimit：" + physicalMemoryLimit + "%");
            var cacheMemoryLimit = (cache2 as MemoryCache).CacheMemoryLimit;
            Console.WriteLine("cacheMemoryLimit：" + Convert.ToDouble(cacheMemoryLimit) + "Byte");
            Console.WriteLine("End");
        }
    }
}
