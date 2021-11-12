using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Module3HW6
{
    public class Starter
    {
        public void Run()
        {
            var locker = new object();
            var queue = new Queue<int>();
            var fPublisher = new FirstPublisher(queue, locker);
            var sPublisher = new SecondPublisher(queue, locker);
            var subscriber = new Subscriber(queue, locker);

            var firstThread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    fPublisher.AddNumberToQueue();

                    Thread.Sleep(500);
                }
            });

            var secondThread = new Thread(() =>
            {
                for (var i = 0; i < 10; i++)
                {
                    sPublisher.AddNumberToQueue();

                    Thread.Sleep(1000);
                }
            });

            var thirdThread = new Thread(() =>
            {
                Thread.Sleep(100);

                while (queue.Count > 0)
                {
                    subscriber.Update();

                    Thread.Sleep(1200);
                }
            });

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();
        }
    }
}
