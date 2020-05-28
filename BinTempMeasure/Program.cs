using System;
using System.IO;

namespace BinTempMeasure
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePAth = $"{Environment.CurrentDirectory}\\data.bin";
            
            int[] testArr = new[] {1, 2, 3, 4, 5};
            WriteFile(testArr, filePAth);

            // Первый запуск:
            // Создаем начальный массив и записываем его в файл в конце

            // Повторный запуск:
            // Считываем массив с файла
            // Спрашиваем хочет ли пользователь добавить эл-ты в массив
            // Добавляем элементы в массив и в конце программы записываем новый массив в файл

        }


        // Считываем информацию с файла
        private int[] ReadFile(string filePath)
        {
            int count = 0;
            int[] data = new int[count];
            return data;
        }
        
        // Запись информации в файл
        private static void WriteFile(int[] data, string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                foreach (int temperature in data)
                {
                    writer.Write(temperature);
                }
            }
        }
    }
}