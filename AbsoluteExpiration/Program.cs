using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GC
{
    class Program
    {
        #region SlidingExpiration 多久時間cache沒有被使用就回收
        static void Main(string[] args)
        {
            ////=================多久時間回收測試=======================
            ObjectCache cache2 = MemoryCache.Default;
            //設定回收時間
            var policy = new CacheItemPolicy();

            //多久時間cache沒有被使用就回收
            policy.SlidingExpiration = TimeSpan.FromSeconds(5);
            cache2.Set("test", "testing", policy);

            var goSecs = new List<int> { 4, 8, 12, 19 };
            int WhileGo = 30;
            int i = 1;
            while (i <= WhileGo)
            {
                Thread.Sleep(1000);//延遲1000ms，也就是1秒
                if (goSecs.Contains(i))
                {
                    Console.WriteLine("while Go " + i + " " + DateTime.Now + " cacheValue:" + cache2["test"]);
                }
                i++;
            }
            Console.WriteLine("\n" + "End");
        }
        #endregion
    }
}
