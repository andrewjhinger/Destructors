using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Destructors
{
    class MyBag
    {
        public string testa = "This is the first string that requires memory allocation on the heap";
        public string testb = "This is the second string that requires memory allocation on the heap";
        public string testc = "This is the third that requires memory allocation on the heap";


        public List<object> Items { get; set; }

        private Stopwatch _stopWatch = new Stopwatch();

        public MyBag()
        {
            _stopWatch.Start();
            Console.WriteLine("MyBag constructor, start stop watch");
            Items = new List<object>();
        }

        ~MyBag()
        {
            _stopWatch.Stop();
            Console.WriteLine("MyBag destructor, stop watch stopped, object existed for " +
                _stopWatch.ElapsedMilliseconds / 1000 + " seconds");
        }

    }
}
