using System;
using System.Collections.Generic;

namespace LargestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] 
            {
                {2, 5, 1, 0},
                {3, 3, 1, 9},
                {4, 4, 7, 8}
            };

            var x = SuitableNeighbours(matrix, 0, 0);


            Console.WriteLine();
        }

        public static List<(int x, int y)> SearchMaxPath(int[,] matrix)
        {
            // Список обойденных вершин, которые образуют максимальный путь
            List<(int x, int y)> largestPath = new List<(int x, int y)>();

            


            return largestPath;
        }
        
        // Список подходящих соседей
        public static List<(int x, int y)> SuitableNeighbours(int[,] matrix, int x, int y)
        {
            List<(int x, int y)> neighbours = new List<(int x, int y)>();

            // Вершина (значение)
            int node = matrix[x, y];
            
            // Left сосед
            if (CheckNeighbour(matrix, x - 1, y))
            {
                if (matrix[x - 1, y] > node)
                {
                    neighbours.Add((x - 1, y));
                }
            }
            
            // Right сосед
            if (CheckNeighbour(matrix, x + 1, y))
            {
                if (matrix[x + 1, y] > node)
                {
                    neighbours.Add((x + 1, y));
                }
            }
            
            // Down сосед
            if (CheckNeighbour(matrix, x, y - 1))
            {
                if (matrix[x, y - 1] > node)
                {
                    neighbours.Add((x, y - 1));
                }
            }
            
            // Up сосед
            if (CheckNeighbour(matrix, x, y + 1))
            {
                if (matrix[x, y + 1] > node)
                {
                    neighbours.Add((x, y + 1));
                }
            }
            
            return neighbours;
        }

        // Проверяем,что сосед существует
        public static bool CheckNeighbour (int[,] matrix, int x, int y)
        {
            try
            {
                var neighbour = (matrix[x, y], (x, y));
                return true;
            }
            catch (Exception e)
            {
                return false;
                
            }
            
        }
        
    }
}