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
           
           // Имя файла по пути
           //var x = Path.GetFileName();
           
           // Все файлы
           var y = GetAllFiles(s);

           var z = CreatHashTable(y);
           
           Console.WriteLine(s);
        }

        // Строим словарь hashCode : список файлов
        public static Dictionary<byte, List<string>> HashDict(List<string>[] hashTable)
        {
            Dictionary<byte, List<string>> dict = new Dictionary<byte, List<string>>();
            
            for (int i = 0; i < hashTable.Length; i++)
            {
                if (hashTable[i] != null)
                {
                    dict[(byte)i] = hashTable[i];
                }
            }

            return dict;
        }

        // Строим хэш-таблицу файлов
        public static List<string>[] CreatHashTable(string[] files)
        {
            List<string>[] hashTable = new List<string>[256];
            foreach (var file in files)
            {
                // Имя файла
                string fileName = Path.GetFileName(file).ToLower();
                byte hashCode = GetHash(fileName);

                try
                {
                    hashTable[hashCode].Add(file);
                }
                catch (Exception e)
                { 
                    hashTable[hashCode] = new List<string>();
                    hashTable[hashCode].Add(file);
                }

            }

            return hashTable;
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