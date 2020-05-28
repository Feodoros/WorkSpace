﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinTempMeasure
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePAth = $"{Environment.CurrentDirectory}\\data.bin";
            
            double[] testArr = new double[]
            {
                50.9, 45.6, 50.9, 45.6 , 
                50.9, 45.6, 50.9, 45.6,
                50.9, 45.6, 50.9, 45.6,
                50.9, 45.6, 50.9, 45.6,
                50.9, 45.6, 50.9, 45.6
            };
            
            double x = MeanTemperature(testArr);
            
            WriteFile(testArr, filePAth);

            
            
            double[] data = ReadFile(filePAth);

            
            // Первый запуск:
            // Создаем начальный массив и записываем его в файл в конце

            // Повторный запуск:
            // Считываем массив с файла
            // Спрашиваем хочет ли пользователь добавить эл-ты в массив
            // Добавляем элементы в массив и в конце программы записываем новый массив в файл

        }


        // Считываем информацию с файла
        private static double[] ReadFile(string filePath)
        {
            List<double> listData = new List<double>(){};

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
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