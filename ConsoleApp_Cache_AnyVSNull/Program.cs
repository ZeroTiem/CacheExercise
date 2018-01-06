using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Cache_AnyVSNull
{
    class Program
    {
        static void Main(string[] args)
        {
            ////=================多久時間回收測試=======================
            ObjectCache cache2 = MemoryCache.Default;
            var policy = new CacheItemPolicy();//設定回收時間
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(3.0);//多久時間清除快取項目
            cache2.Set("test", "testing", policy);
            int WhileGo = 100;
            int i = 1;
            while (i <= WhileGo)
            {
                Console.WriteLine("while Go " + i + " " + DateTime.Now + " cacheValue:" + cache2["test"]);

                //Thread.Sleep(1000);//延遲1000ms，也就是1秒
                //Console.WriteLine("while Go " + i + " " + DateTime.Now + " cacheValue:" + cache2["test"]);
                i++;
            }
            Console.WriteLine("\n" + DateTime.Now.ToString() + "  " + cache2["test"]);
            Console.WriteLine("\n" + "End");
        }

        private static bool IsAny(ObjectCache objectCache)
        {
            return objectCache.Any();
        }

        private static bool IsNullorEmtiy(ObjectCache objectCache)
        {
            return objectCache != null;
        }
    }
}
