using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Cache_Recycling
{
    class Program
    {
        static void Main(string[] args)
        {
            ////=================多久時間回收測試=======================
            ObjectCache cache2 = MemoryCache.Default;
            //var policy = new CacheItemPolicy();//設定回收時間
            //policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(15.0);//多久時間清除快取項目
            //cache2.Set("test", "testing", policy);

            Console.WriteLine("===ConsoleApp_Cache_SetConfig===");
            var physicalMemoryLimit = (cache2 as MemoryCache).PhysicalMemoryLimit;
            Console.WriteLine("physicalMemoryLimit：" + physicalMemoryLimit + "%");
            var cacheMemoryLimit = (cache2 as MemoryCache).CacheMemoryLimit;
            Console.WriteLine("cacheMemoryLimit：" + Convert.ToDouble(cacheMemoryLimit)/1024/1024 + "Byte");
            Console.WriteLine("End");
            Thread.Sleep(1000);//延遲1000ms，也就是1秒
            //var aa  = new StringBuilder();

            //var cpus = 4;
            long WhileGo = 99999999999999;
            int i = 500;
            int MB = 0;
            int ByteToMB = 1024 * 1024;

            try
            {
                while (i <= WhileGo)
                {
                    //Thread.Sleep(1000);//延遲1000ms，也就是1秒
                    cache2["test"] = new byte[i * (1024 * 1024)];
                    MB = Convert.ToInt32(i);
                    Console.WriteLine("while Go " + i + " " + DateTime.Now + " cacheValue:" + ((byte[])cache2["test"]).LongLength / 1024 / 1024 + "MB");
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error MemorySize:" + (MB + 1));
                //throw;
            }
            //Console.WriteLine("\n" + DateTime.Now.ToString() + "  " + cache2["test"]);
            Console.WriteLine("\n" + "End");

            //OutOfMemoryException.
        }
    }
}
