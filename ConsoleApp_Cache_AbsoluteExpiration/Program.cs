using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp_Cache_AbsoluteExpiration
{
    class Program
    {
        #region AbsoluteExpiration cache 多久後被回收
        static void Main(string[] args)
        {
            ////=================多久時間回收測試=======================
            ObjectCache cache2 = MemoryCache.Default;
            var policy = new CacheItemPolicy();//設定回收時間
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(15.0);//多久時間清除快取項目
            cache2.Set("test", "testing", policy);
            int WhileGo = 20;
            int i = 1;
            while (i <= WhileGo)
            {
                Thread.Sleep(1000);//延遲1000ms，也就是1秒
                Console.WriteLine("while Go " + i + " " + DateTime.Now + " cacheValue:" + cache2["test"]);
                i++;
            }
            Console.WriteLine("\n" + DateTime.Now.ToString() + "  " + cache2["test"]);
            Console.WriteLine("\n" + "End");
        }
        #endregion
    }
}
