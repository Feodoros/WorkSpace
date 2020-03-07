using System;
using System.Text;
using System.Collections.Generic;

namespace Collections_GenericHomeTask
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("введите N");
            int N = Convert.ToInt32(Console.ReadLine());
            Dictionary<int, int> num = new Dictionary<int, int>(N);

            SquareNum(num, N);
        }

        static void SquareNum(Dictionary<int, int> num, int N)
        {
            int[] key = new int[N];
            int[] value = new int[N];

            for (int i = 0; i < N; i++)
            {
                key[i] = i;
                value[i] = i * i;
                Console.WriteLine($"{key[i]} -- {value[i]}");
            }
        }
    }
}