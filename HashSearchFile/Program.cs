using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashSearchFile
{
    class Program
    {
        static void Main(string[] args)
        {
           var s =  @"C:\Users\Fedor\Desktop\Test";

           int[] s1 = new[] {1, 2, 3, 4};
           int[] s2 = new[] {5, 6, 7, 8};
           int[] res = s1.Concat(s2).ToArray();
           // Имя файла по пути
           //var x = Path.GetFileName();
           
           // Все файлы
           var y = GetAllFiles(s);
           
           
           
           Console.WriteLine(s);
        }
        
        // Получаем хэш-код от имени файла
        public static byte GetHash(string fileName)
        {
            uint code = 0; 
            foreach (var letter in fileName)
            {
                code += letter;
            }
            return (byte) (code % 256U);
        }

        // Получаем все файлы во всех каталогах
        public static string[] GetAllFiles(string path)
        {
            return RecSearchFiles(path, new string[]{});
        }

        // Рекурсивный поиск файлов
        public static string[] RecSearchFiles(string path, string[] paths)
        {
            // Список файлов в папке
            string[] files = Directory.GetFiles(path);

            paths = paths.Concat(files).ToArray();

            // Список папок в папке
            string[] directories = Directory.GetDirectories(path);
            
            if (directories.Length != 0)
            {
                foreach (var directory in directories)
                {
                    return RecSearchFiles(directory, paths);
                }
            }
            return paths;
        }
    }
}