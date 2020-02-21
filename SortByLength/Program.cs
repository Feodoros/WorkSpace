using System;
using System.Linq;

namespace SortByLength
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arrays = new[]
            {
                new int[] {289, 200, 101, 90, 230}, new int[] {100, 289, 200, 101},
                new int[] {100, 289, 205, 101, 90, 230}, new int[] {100, 289, 200, 101, 90, 230}
            };

            Sort(arrays);
            
            Console.WriteLine(arrays);
        }
        
        
        private static void Sort(int[][] arrays)
        {
            for (int i = 0; i < arrays.Length - 1; i++)
            {
                if (arrays[i].Length > arrays[i + 1].Length)
                {
                    int[] tempArr = arrays[i+1];
                    arrays[i + 1] = arrays[i];
                    arrays[i] = tempArr;
                    Sort(arrays);
                }

                if (arrays[i].Length == arrays[i + 1].Length)
                {
                    if (arrays[i].Sum() < arrays[i + 1].Sum())
                    {
                        int[] tempArr = arrays[i+1];
                        arrays[i + 1] = arrays[i];
                        arrays[i] = tempArr;
                        Sort(arrays);
                    }
                }
            }
        }
        
        // ДЗ: реализовать сортировку вставками/слиянием (Merge Sort)
        // И выложить на GitHub
    }
}