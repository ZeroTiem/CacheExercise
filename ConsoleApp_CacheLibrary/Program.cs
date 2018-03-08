using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CacheLibrary;
using System.Web.Script.Serialization;

namespace ConsoleApp_CacheLibrary
{
    class Program
    {
        private static string key = "CacheTestDatas";
        static void Main(string[] args)
        {
            //var cacheLibrary = new CacheLibrary.CacheLibrary();

            //cacheLibrary.Set(key, "1");

            Thread myThread = new Thread(myRun);
            myThread.Start();
            Cache.Set(key, Console.ReadLine());
            Console.WriteLine(jsoncache());

            Cache.Clear(key);
            Console.WriteLine(jsoncache());

            Cache.Set(key, Console.ReadLine());
            Console.WriteLine(jsoncache());
        }

        static void myRun()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("myRun：" + jsoncache());
            }
        }

        static string jsoncache()
        {
            var output = new JavaScriptSerializer().Serialize(Cache.Get<string>(key));
            return output;
        }
    }
}
