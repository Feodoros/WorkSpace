using System;
using System.Collections.Generic;
using System.Linq;

namespace Cross
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "УЛИТКА", "ПОТОК", "ПЛЮЩ", "БУМ", "СМЕХ" };
            string mainWord = "ЛОПУХ";

            List<char[]> finalTable = MakeTable(words, mainWord);
            Print(finalTable, mainWord);
            Console.ReadKey();
        }

        static List<char[]> MakeTable (string[] words, string mainWord)
        {
            // Массив номеров пересечения слов со словом по вертикали
            int[] indexes = new int[mainWord.Length];
            
            List<char[]> finalWords = new List<char[]>();
            
            for (int i = 0; i < mainWord.Length; i++)
            {
                int index = words[i].IndexOf(mainWord[i]);

                if (index == -1 || mainWord.Length != words.Length)
                    ImpossibleMakingCross();
                
                indexes[i] = index;
            }
            
            // Максимально дальнее пересечение
            int max = indexes.Max();
            
            // Далее дополняем каждое слово пробелами, чтобы все слова пересекали слово
            // По вертикали в одном и том же столбце (номер столбца -- максимально дальнее пересечение)
            for (int i = 0; i < words.Length; i++)
            {
                // Количество пробелов, которое вставим в начало
                int numOfSpaces = max - indexes[i];  
                char[] spaces = new char[numOfSpaces];
                
                for (int j = 0; j < numOfSpaces; j++)
                {
                    spaces[j] = ' ';
                }    
                
                // Финальное слово -- элемент вида [ ][ ][ ]...[ ][w][o][r][d]
                char[] finalWord = new char[words[i].Length + spaces.Length];
                spaces.CopyTo(finalWord, 0);
                words[i].ToCharArray().CopyTo(finalWord, spaces.Length);
                
                finalWords.Add(finalWord);
            }

            return finalWords;
        }

        static void Print(List<char[]> words, string mainWord)
        {
            for (int i = 0; i < words.Count; i++)
            {
                bool isFirst = true;
                for (int j = 0; j < words[i].Length; j++)
                {   
                    // Проверяем, что закрашенная буква -- первая
                    // общая буква со словом по вертикали.
                    if (words[i][j] == mainWord[i] && isFirst)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        isFirst = false;
                    }
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.Write(words[i][j] + " ");
                }
                
                Console.WriteLine();
            }
        }

        static void ImpossibleMakingCross()
        {
            Console.WriteLine("Невозможно составить кроссворд.");
            Environment.Exit(-1);
        }
    }
}