using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] 
            {
                {2, 5, 1, 10},
                {3, 3, 1, 9},
                {4, 4, 7, 8}
            };

            var x = SuitableNeighbours(matrix, 0, 0);
            
            List<List<(int, int)>> m = new List<List<(int, int)>>();
            List<(int, int)> y = new List<(int, int)>(); 
            var z = SearchMaxPathInMatrix(matrix);
            
            Console.WriteLine();
        }

        // Поиск максимального пути
        public static List<(int x, int y)> SearchMaxPathInMatrix(int[,] matrix)
        {
            // Максимальный путь
            List<(int x, int y)> largestPath = new List<(int x, int y)>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    List<(int, int)> maxPathFromNode = SearchMaxPath(matrix, i, j, new List<(int x, int y)>(),
                        new List<List<(int x, int y)>>());
                    if (maxPathFromNode.Count > (largestPath.Count))
                    {
                        largestPath = maxPathFromNode;
                    }
                }
            }
            
            return largestPath;
        }
        
        // Максимальный путь из вершины
        private static List<(int x, int y)> SearchMaxPath(int[,] matrix, int i, int j, List<(int x, int y)> path, List<List<(int x, int y)>> paths)
        {
            // Подходящте соседи
            List<(int x, int y)> neighbours = SuitableNeighbours(matrix, i, j);
            
            // Добавялем путь, если нет соседей
            if (neighbours.Count == 0)
            {
                paths.Add(new List<(int, int)>(path));
            }
            
            if (neighbours.Count > 0)
            {
                foreach (var neighbour in neighbours)
                {
                    if (path.Count == 0)
                    {
                        path.Add((i, j));
                    }
                    
                    path.Add(neighbour);
                    SearchMaxPath(matrix, neighbour.x, neighbour.y, path, paths);
                    path.Remove(neighbour);
                }
            }

            return paths.OrderByDescending(path => path.Count).First();
        }
        

        // Список подходящих соседей
        private static List<(int x, int y)> SuitableNeighbours(int[,] matrix, int x, int y)
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
        private static bool CheckNeighbour (int[,] matrix, int x, int y)
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