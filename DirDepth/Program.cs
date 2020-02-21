using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace DirectoryDeepth
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тестовый путь.
            GoDeep("/Users / ketra / Desktop/WorkSpace");

            // Тут сортируем все полученные пути папок, берем первый (самый длинный путь)
            // И сплитим его по '\\' чтобы получить число вложенности
            var mostDeepDirectory = _directoriesList.Cast<string>().OrderBy(s => s.Split('\\').Length).Last();
            var depth = mostDeepDirectory.Split(Path.DirectorySeparatorChar).Length;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Папка: {mostDeepDirectory} \n Глубина: {depth}");
        }



        // Список всех папок 
        private static ArrayList _directoriesList = new ArrayList();

        // Идем в каждую папку рекурсивно и добавляем все пути папок из этой папки в список путей
        // Далее для каждой новой папки действия повторяются
        // Грубо говоря, спускаемся вниз попутно добавляя папки в список
        private static void GoDeep(string path)
        {
            string[] directories = Directory.GetDirectories(path);
            // Если в папке нет папок, то возвращаемся 
            if (directories.Length <= 0) return;
            foreach (string dir in directories)
            {
                _directoriesList.Add(dir);
                GoDeep(dir);
            }
        }
    }
}