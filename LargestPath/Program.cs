using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
            
            List<(int,int)> maxPathInMatrix = SearchMaxPath(matrix);
            OutputResult(matrix, maxPathInMatrix);
        }

        // Поиск максимального пути
        private static List<(int x, int y)> SearchMaxPath(int[,] matrix)
        {
            // Максимальный путь
            List<(int x, int y)> largestPath = new List<(int x, int y)>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    List<(int, int)> maxPathFromNode = SearchMaxPathFromNode(matrix, i, j, new List<(int x, int y)>(),
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
        private static List<(int x, int y)> SearchMaxPathFromNode(int[,] matrix, int i, int j, List<(int x, int y)> path, List<List<(int x, int y)>> paths)
        {
            if (path.Count == 0)
            {
                path.Add((i, j));
            }
            
            // Подходящте соседи
            List<(int x, int y)> neighbours = GetSuitableNeighbours(matrix, i, j);
            
            // Добавялем путь, если нет соседей
            if (neighbours.Count == 0)
            {
                paths.Add(new List<(int, int)>(path));
            }
            
            if (neighbours.Count > 0)
            {
                foreach (var neighbour in neighbours)
                {
                    path.Add(neighbour);
                    SearchMaxPathFromNode(matrix, neighbour.x, neighbour.y, path, paths);
                    path.Remove(neighbour);
                }
            }

            return paths.OrderByDescending(path => path.Count).First();
        }
        
        // Список подходящих соседей
        private static List<(int x, int y)> GetSuitableNeighbours(int[,] matrix, int x, int y)
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
        
        // Вывод результата
        private static void OutputResult(int[,] matrix, List<(int, int)> largestPath)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Маршрут по ячейкам: ");
            foreach (var element in largestPath)
            {
                Console.Write(element);
                if (element != largestPath.Last())
                {
                    Console.Write("-");
                }
               
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Маршрут по значениям: ");
            foreach (var element in largestPath)
            {
                Console.Write(matrix[element.Item1, element.Item2]);
                if (element != largestPath.Last())
                {
                    Console.Write("-");
                }
            }
        } 
    }
}