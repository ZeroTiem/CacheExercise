using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化
            ObjectCache cache = MemoryCache.Default;
            cache["test1"] = "1";
            cache["test2"] = 2;
            cache["test3"] = new test3 { Key = 1, Name = "hank", Value = "OOXX" };
            Console.WriteLine(cache["test1"]);
            Console.WriteLine(cache["test2"]);
            var json = new JavaScriptSerializer().Serialize((cache["test3"] as test3));
            Console.WriteLine(json);
        }
    }

    public class test3
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
