using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Cache_MemoryCache
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectCache cache2 = MemoryCache.Default;

            var Policy = new CacheItemPolicy();
            Policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1);
           
            //var aa = MemoryCache.Default;
           
            string maxText = "";
            for (int j = 0; j < 32767; j++)
            {
                maxText += "a";
            }

            int i = 0;
            while (true)
            {
                //Thread.Sleep(1000);//延遲1000ms，也就是1秒

                //Console.WriteLine("physicalMemoryLimit：" + physicalMemoryLimit);
                //var physicalMemoryLimit = (cache2 as MemoryCache).PhysicalMemoryLimit;

                var cacheMemoryLimit = (cache2 as MemoryCache).CacheMemoryLimit;
                Console.WriteLine("cacheMemoryLimit：" + Convert.ToDouble(cacheMemoryLimit) + "Byte");

                //var defaultCacheMemoryLimit = MemoryCache.Default.CacheMemoryLimit;
                //var defaultCacheMemoryLimit = cache2.DefaultCacheCapabilities;
                //Console.WriteLine("defaultCacheMemoryLimit：" + Convert.ToDouble(defaultCacheMemoryLimit) + "Byte");





                //cache2[i.ToString()] = maxText;
                //cache2.Set(i.ToString(), maxText, Policy);
                //var defaultCacheMemoryLimit = aa.PollingInterval.ToString();
                //Console.WriteLine("PollingInterval：" + aa.PollingInterval);
                //Console.WriteLine("defaultCacheMemoryLimit：" + aa.CacheMemoryLimit + "Byte");
                //aa[i.ToString()] = maxText;


                i++;
            }

            Console.WriteLine("\n" + "End");
        }
    }
}
