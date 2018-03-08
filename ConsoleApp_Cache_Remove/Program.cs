using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp_Cache_Remove
{
    class Program
    {
        static void Main(string[] args)
        {
            ////=================多久時間回收測試=======================
            ObjectCache cache = MemoryCache.Default;
            //設定回收時間
            var policy = new CacheItemPolicy();
            //多久時間cache沒有被使用就回收
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(3.0);//多久時間清除快取項目
            policy.RemovedCallback = CacheItemRemoved;//如果資訊有移除要做什麼事情
            object objectvalue = "Data";//要存儲的資訊
            cache.Set("test", objectvalue, policy);//設定cache並且給予值
            int WhileGo = 30;
            int i = 1;
            while (i <= WhileGo)
            {
                Thread.Sleep(1000);//延遲1000ms，也就是1秒
                Console.WriteLine("while Go " + i + " " + DateTime.Now + " cacheValue:" + cache["test"]);
                i++;
            }
            Console.WriteLine("\n" + "End");
        }
        static void CacheItemRemoved(CacheEntryRemovedArguments arguments)
        {
            // The arguments object contains information about the removed item such as: 
            var key = arguments.CacheItem.Key;
            var removedObject = arguments.CacheItem.Value;
            var removedReason = arguments.RemovedReason;
            Console.WriteLine($"[Run cacheItemRemoved] key:{ key } / removedObject:{ removedObject } / removedReason:{ removedReason }");
        }
    }
}
