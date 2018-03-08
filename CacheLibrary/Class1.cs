using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace CacheLibrary
{
    public static class Cache
    {
        public static ObjectCache cache = MemoryCache.Default;

        public static void Set(string key, object obj)
        {
            //string cacheName = typeof(T).ToString();
            //設定回收時間
            var policy = new CacheItemPolicy();
            //多久時間cache沒有被使用就回收
            policy.SlidingExpiration = TimeSpan.FromSeconds(180);
            cache.Set(key, obj, policy);
        }

        public static T Get<T>(string key)
        {
            return (T)cache[key];
        }

        public static void Clear(string key)
        {
            cache.Remove(key);
        }

        //public T Reload<T>()
        //{

        //}
    }

    //public class CacheTestData
    //{
    //    public int key { get; set; }
    //    public string value { get; set; }
    //}
}
