using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW6.Abstractions;

namespace Module3HW6
{
    public class SecondPublisher : Publisher
    {
        private object _locker;

        public SecondPublisher(Queue<int> queue, object locker)
            : base(queue)
        {
            _locker = locker;
        }

        public override void AddNumberToQueue()
        {
            lock (_locker)
            {
                var rand = new Random().Next(11, 20);
                Queue.Enqueue(rand);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[2] Добавил число: {rand}.");
                Console.ResetColor();
            }
        }
    }
}
