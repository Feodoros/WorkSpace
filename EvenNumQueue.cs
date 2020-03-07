using System;
using System.Text;
using System.Collections.Generic;

namespace queue
{
    class MainClass
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Queue<int> queue = new Queue<int>();

            Random rnd = new Random();

            while (queue.Count != 10)
                queue.Enqueue(rnd.Next(1, 99));

            Print(queue);

            while (queue.Peek() % 2 != 0)
            {
                queue.Dequeue();
            }

            if (queue.Peek() % 2 != 0)
                Console.WriteLine("к сожалению, чётных чисел не нашлось. заходите завтра");

            Print(queue);
        }

        static void Print(Queue<int> queue)
        {
            foreach (var qu in queue)
            {
                Console.Write(qu + " ");
            }
            Console.WriteLine("\n");
        }
    }
}