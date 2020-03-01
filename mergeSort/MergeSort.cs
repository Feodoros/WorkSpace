using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merge_sort
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<int> unsorted = new List<int>();

            int[] arr = new int[] { 289, 200, 101, 90, 230 };
            for (int i = 0; i < arr.Length; i++)
                unsorted.Add(arr[i]);

            Console.WriteLine("Неотсортированный массив");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Print(unsorted);

            Console.ResetColor();
            Console.WriteLine("Отсортированный массив");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Print(Sort(unsorted));
        }

        public static List<int> Sort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left;
            List<int> right;

            int mid = unsorted.Count / 2;

            left = unsorted.Take(mid).ToList();
            right = unsorted.Skip(mid).ToList();

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        public static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
            }
            return result;
        }

        public static void Print(List<int> unsorted)
        {
            foreach (int x in unsorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
        }
    }
}