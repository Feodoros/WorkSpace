using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BinTempMeasure
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePAth = $"{Environment.CurrentDirectory}\\data.bin";
            
            double[] dataArr;
            
            // Первый запуск
            if (!File.Exists(filePAth))
            {
                double[] defaultArr = new double[]
                {
                    50.9, 45.6, 50.9, 45.6 , 
                    50.9, 45.6, 50.9, 45.6,
                    50.9, 45.6, 50.9, 45.6,
                    50.9, 45.6, 50.9, 45.6,
                    50.9, 45.6, 50.9, 45.6
                };

                dataArr = defaultArr;
            }
            
            // Повторный запуск
            else
            {
                dataArr = ReadFile(filePAth);
            }
            
            double mean = MeanTemperature(dataArr);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Среднее арифметическое: {mean}");
            Console.ResetColor();

            WriteFile(dataArr, filePAth);
            
        }


        // Считываем информацию с файла
        private static double[] ReadFile(string filePath)
        {
            List<double> listData = new List<double>(){};

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open), Encoding.ASCII))
            {
                while (reader.PeekChar() > -1)
                {
                    listData.Add(Math.Round(reader.ReadDouble(), 2));
                }
            }
            
            return listData.ToArray();
        }
        
        // Запись информации в файл
        private static void WriteFile(double[] data, string filePath)
        {
            // Чистим файл
            using(FileStream fs = File.Open(filePath,FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock(fs)
                {
                    fs.SetLength(0);
                }
            }
            
            // Записываем в файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.OpenOrCreate)))
            {
                foreach (double temperature in data)
                {
                    writer.Write(Math.Round(temperature, 2));
                }
            }
        }

        // Вычисляем среднее значение температур (отбрасывая 5% сверху и снизу)
        private static double MeanTemperature(double[] data)
        {
            double mean = 0;
            
            List<double> dataList = data.ToList();
            dataList.Sort();
            
            int fivePerCent = dataList.Count / 20;
            
            for (int i = 0; i < fivePerCent; i++)
            {
                dataList.RemoveAt(0);
                dataList.RemoveAt((dataList.Count - 1));
            }

            mean = dataList.Sum() / dataList.Count;
            
            return mean;
        }
    }
}