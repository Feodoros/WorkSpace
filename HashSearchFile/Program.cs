using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace HashSearchFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите адрес папки: ");
            string path = Console.ReadLine().Replace(" ", "");

            // Список всех файлов
            string[] files = GetAllFiles(path);

            // Словарь hashCode : Список файлов (с этим хэшем)
            Dictionary<byte, List<string>> dictionary = HashDict(CreatHashTable(files));

            // Тело программы 
            int num = 0;
            while (num != 1)
            {
               Console.WriteLine("0 -- Поиск файла **** 1 -- Выйти из программы");
               try
               {
                   num = Int32.Parse(Console.ReadLine());
               }
               catch (Exception e)
               {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Введите 0 или 1!");
                   Console.ResetColor();
                   num = -1;
               }

               if (num == 1)
               {
                   Environment.Exit(0);
               }

               if (num == 0)
               {
                   Console.WriteLine("Введите название файла: ");
                   string fileName = Console.ReadLine().ToLower().Replace(" ", "");
                   byte hashCode = GetHash(fileName);
                   
                   try
                   {
                       // Список файлов с хэшом hashCode
                       List<string> filesWithSameHash = dictionary[hashCode];
                       bool flag = true;
                       foreach (var fullPath in filesWithSameHash)
                       {
                           string name = Path.GetFileName(fullPath).ToLower();
                           if (name == fileName)
                           {
                               flag = false;
                               Console.ForegroundColor = ConsoleColor.Cyan;
                               Console.WriteLine(fullPath);
                               Process.Start(@"cmd.exe ", @"/c " + fullPath);
                               Console.ResetColor();
                           }
                       }

                       if (flag)
                       {
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.WriteLine("Нет такого файла.");
                           Console.ResetColor();
                       }
                       
                   }
                   catch (Exception e)
                   {
                       Console.ForegroundColor = ConsoleColor.Red;
                       Console.WriteLine("Нет такого файла.");
                       Console.ResetColor();
                   }

               }

               if(num != 0 && num != 1 && num != -1)
               {
                   Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Введите 0 или 1!");
                   Console.ResetColor();
               }
               
            }

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
            try
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

            catch (UnauthorizedAccessException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Отказано в доступе");
                Console.ResetColor();
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет такой папки");
                Console.ResetColor();
                throw;
            }
            
        }
    }
}