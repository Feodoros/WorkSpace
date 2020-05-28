using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {4, 3, 8, 1, 5, 9, 6};
            arr = MergeSort(arr);
            
            Array.ForEach(arr, element => Console.Write(element));
            Console.ReadKey();
        }
        
        
        static Int32[] MergeSort(Int32[] massive)
        {
            if (massive.Length == 1)
                return massive;
            
            Int32 mid_point = massive.Length / 2;
            return Merge(MergeSort(massive.Take(mid_point).ToArray()), MergeSort(massive.Skip(mid_point).ToArray()));
        }
 
        static Int32[] Merge(Int32[] mass1, Int32[] mass2)
        {
            Int32 a = 0, b = 0;
            Int32[] merged = new int[mass1.Length + mass2.Length];
            for (Int32 i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else
                if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }
    }
}