using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Destructors
{
    class Bag
    {
        public List<object> Items { get; set; }

        private Stopwatch _stopWatch = new Stopwatch();

        public Bag()
        {
            _stopWatch.Start();
            Console.WriteLine("Bag constructor, start stop watch");
            Items = new List<object>();
        }

        ~Bag()
        {
            _stopWatch.Stop();
            Console.WriteLine("Bag destructor, stop watch stopped, object existed for " +
                _stopWatch.ElapsedMilliseconds / 1000 + " seconds");
        }
    }
}