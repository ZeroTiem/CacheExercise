using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Universal
{
    public static class CacheManager
    {
        /// <summary>
        /// 取得可以被Cache的資料(注意：非Thread-Safe)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Cache保存號碼牌</param>
        /// <param name="callback">傳回查詢資料的函數</param>
        /// <param name="cacheMins"></param>
        /// <param name="forceRefresh">是否清除Cache，重新查詢</param>
        /// <returns></returns>
        public static T GetCachableData<T>(string key, Func<T> callback,
            int cacheMins, bool forceRefresh = false) where T : class
        {
            ObjectCache cache = MemoryCache.Default;
            string cacheKey = key;

            T res = cache[cacheKey] as T;
            //是否清除Cache，強制重查
            if (res != null && forceRefresh)
            {
                cache.Remove(cacheKey);
                res = null;
            }
            if (res == null)
            {
                res = callback();
                cache.Add(cacheKey, res,
                    new CacheItemPolicy()
                    {
                        SlidingExpiration = new TimeSpan(0, cacheMins, 0)
                    });
            }
            return res;
        }


        /// <summary>
        /// 取得可以被Cache的資料(注意：非Thread-Safe)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Cache保存號碼牌</param>
        /// <param name="callback">傳回查詢資料的函數</param>
        /// <param name="absExpire">有效期限</param>
        /// <param name="forceRefresh">是否清除Cache，重新查詢</param>
        /// <returns></returns>
        public static T GetCachableData<T>(string key, Func<T> callback,
            DateTimeOffset absExpire, bool forceRefresh = false) where T : class
        {
            ObjectCache cache = MemoryCache.Default;
            string cacheKey = key;
            //取得每個Key專屬的鎖定對象
            T res = cache[cacheKey] as T;
            //是否清除Cache，強制重查
            if (res != null && forceRefresh)
            {
                cache.Remove(cacheKey);
                res = null;
            }
            if (res == null)
            {
                res = callback();
                cache.Add(cacheKey, res, new CacheItemPolicy()
                {
                    AbsoluteExpiration = absExpire
                });
            }
            return res;
        }
    }
}
