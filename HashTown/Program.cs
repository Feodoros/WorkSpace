using System;

namespace HashTown
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] arrTowns = {"Люберцы", "Город 2"};
            
            string[] hashTable = MakeHashTable(arrTowns).Item1;
            int count = MakeHashTable(arrTowns).Item2;

            Console.WriteLine();
        }

        public static int GetHash(string strS)
        {
            int res = 0;
            foreach (char c in strS)
            {
                res += c;
            }
            res = res % 256;

            return res;
        }

        public static (string[], int) MakeHashTable(string[] arrTowns)
        {
            int[] arrShifts = { 2, 5, 6 };
            int count = 0;

            string[] hashTable = new string[256];
            foreach (string town in arrTowns)
            {
                int hashCode = GetHash(town.ToUpper());

                if (hashTable[hashCode] == null)
                    hashTable[hashCode] = town.ToUpper();
                else
                {
                    hashCode += arrShifts[count % 3];

                    while (hashTable[hashCode % 256] != null)
                    {
                        hashCode += arrShifts[count % 3];
                        count++;
                    }

                    hashTable[hashCode%256] = town.ToUpper();
                    count++;
                }
            }

            return (hashTable, count);
        }
    }
}