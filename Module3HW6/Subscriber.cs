using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HW6
{
    public class Subscriber
    {
        private Queue<int> _queue;
        private object _locker;

        public Subscriber(Queue<int> queue, object locker)
        {
            _queue = queue;
            _locker = locker;
        }

        public void Update()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            lock (_locker)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[S] Взял:{_queue.Dequeue()}");
                Console.ResetColor();
            }
        }
    }
}
