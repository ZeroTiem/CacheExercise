using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CachingProviderBase
{
    public abstract class CachingProviderBase
    {
        public CachingProviderBase()
        {
            DeleteLog();
        }

        protected ObjectCache cache = MemoryCache.Default;
        //protected MemoryCache cache = new MemoryCache("CachingProvider");

        static readonly object padlock = new object();

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

        #region Error Logs

        string LogPath = System.Environment.GetEnvironmentVariable("TEMP");

        protected void DeleteLog()
        {
            System.IO.File.Delete(string.Format("{0}\\CachingProvider_Errors.txt", LogPath));
        }

        protected void WriteToLog(string text)
        {
            using (System.IO.TextWriter tw = System.IO.File.AppendText(string.Format("{0}\\CachingProvider_Errors.txt", LogPath)))
            {
                tw.WriteLine(text);
                tw.Close();
            }
        }

        #endregion
    }
}
