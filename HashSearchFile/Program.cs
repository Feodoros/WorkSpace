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
           var s =  GetFilesFromDirectory(@"C:\Users\Fedor\Desktop\Test");

           
           // Имя файла по пути
           var x = Path.GetFileName(s.First());
           
           
           Console.WriteLine(s);
        }
        
        // Получаем пути файлов в одной папке
        public static string[] GetFilesFromDirectory(string path)
        {
            return Directory.GetFiles(path);
        }
    }
}