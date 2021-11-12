using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW6.Abstractions
{
    public abstract class Publisher
    {
        public Publisher(Queue<int> queue)
        {
            Queue = queue;
        }

        protected Queue<int> Queue { get; }

        public abstract void AddNumberToQueue();
    }
}
