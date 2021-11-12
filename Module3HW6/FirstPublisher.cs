using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW6.Abstractions;

namespace Module3HW6
{
    public class FirstPublisher : Publisher
    {
        private object _locker;

        public FirstPublisher(Queue<int> queue, object locker)
            : base(queue)
        {
            _locker = locker;
        }

        public override void AddNumberToQueue()
        {
            lock (_locker)
            {
                var rand = new Random().Next(1, 100);
                Queue.Enqueue(rand);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[1] Добавил число: {rand}.");
                Console.ResetColor();
            }
        }
    }
}
