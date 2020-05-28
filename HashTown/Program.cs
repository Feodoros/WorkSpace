using System;
using System.Text;

namespace HashTown
{
    class MainClass
    {
        public static void Main(string[] args)
        {Console.OutputEncoding = Encoding.UTF8;

            string[] arrTowns = {"Абросимовка", "Аксентьево"};
            string[] hashTable = MakeHashTable(arrTowns).Item1;
            int count = MakeHashTable(arrTowns).Item2;

            Console.WriteLine($"Колличество коллизий - {count}. Значение элемента с индексом 3 - {hashTable[3]}");

        }

        public static (string[],int) MakeHashTable(string[] arrTowns)
        {
            //Массив смещений при возникновении коллизии
            int[] arrShifts = { 2, 3, 6 };
            //Колчиество коллизий
            int count = 0;
            //Индекс смещения
            int index = 0;
            //Хэш-таблица
            string[] hashTable = new string[256];
            
            foreach (string town in arrTowns)
            {
                //Хэш-код
                int hashCode = GetHash(town.ToUpper());

                while (true)
                {
                    //Если ячейка в таблице пустая - добавляем элемент туда.
                    if (hashTable[hashCode] == null)
                    {
                        hashTable[hashCode] = town;
                        index = 0;
                        break;
                    }
                    else
                    {
                        //Если ячейка занята, то пересчитываем хэш-код, чтобы
                        //потом добавить в таблицу элемент под этим индексом
                        hashCode = (hashCode + arrShifts[index]) % 256;
                        count++;
                        index = (index+1) % 3;
                    }
                }
            }

            //Возвращаем кортеж, состоящий из хэш-таблицы и количства коллизий
            return (hashTable, count);
        }

        public static int GetHash(string strS)
        {
            int res = 0;
            foreach (char c in strS)
                res += c;
            res = res % 256;

            return res;
        }
    }
}
