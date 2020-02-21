using System;
using System.Text;

namespace BinSearch
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            int[,] arrays = { {-15, -12, -9, -2 }, { -1, 0, 4, 8 }, { 9, 15, 18, 22 }};
            int X = 22;
            
            Print(arrays);
            
            
            if (Finder_2D(arrays, X, out int[] indexI))
            {
                Console.WriteLine($"Число {X} имеет координаты {indexI[0]},{indexI[1]}");
            }
            else
            {
                Console.WriteLine("Число не найдено.");
            }
            Console.ReadKey();
        }

        private static bool Finder_2D(int[,] arrays, int X, out int[] indexI) 
        {
            indexI = new int[] {-1, -1};
            // Тот же бин поиск по массиву, только теперь еще пробегаем каждую строку (массив)
            // Ну и индекс у нас теперь двумерный
            for (int i = 0; i <= arrays.GetUpperBound(0); i++)
            {
                int left, right, mid;
                left = 0;
                right = arrays.GetUpperBound(1);
                
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (arrays[i, mid] == X)
                    {
                        indexI[0] = i;
                        indexI[1] = mid;
                        return true;
                    }

                    if (arrays[i, mid] < X)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return false;
        }

        private static void Print(int[,] arrays)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i <= arrays.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arrays.GetUpperBound(1); j++)
                {
                    Console.Write(arrays[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}