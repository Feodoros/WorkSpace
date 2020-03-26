using System;

namespace HanoiTowards
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi(4, 'A', 'B', 'C');
        }

        static void Hanoi(Int32 n, char from, char to, char temp)
        {
            if (n == 1)
            {
                Console.WriteLine(from + "->" + to);
                return;
            }
            
            Hanoi(n - 1, from, temp, to);
            Console.WriteLine(from + "->" + to);
            Hanoi(n - 1, temp, to, from);
        }
    }
}