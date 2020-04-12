using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace AlgorithmRutishauser
{
    // Тип данных
    public class MyStruct
    {
        public string PartOfString { get; set; }

        public int Lvl { get; set; }
    }

    // Свой список
    public class StructurList<T>
    {
        public T[] data;

        public StructurList(T[] data)
        {
            this.data = data;
        }
        
        // индексатор
        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public int Count()
        {
            return data.Length;
        }
        
        public void Add(T element)
        {
            int n = Count();
            T[] dataNew= new T[n + 1];
            for (int i = 0; i < n; i++)
            {
                dataNew[i] = data[i];
            }

            dataNew[n] = element;

            data = dataNew;
        }

        public void Remove(int index)
        {
            int n = Count();
            T[] dataNew = new T[n];

            if (index == n - 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    dataNew[i] = data[i];
                }
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (index != i)
                    {
                        dataNew[i] = data[i];
                    }
                }
            }
            
            T[] dataNew1 = new T[n-1];
            bool flag = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (dataNew[i] != null && flag) 
                {
                    dataNew1[i] = dataNew[i];
                }
                else
                {
                    flag = false;
                }

                if (!flag)
                {
                    dataNew1[i] = dataNew[i + 1];
                }
            }
            
            data = dataNew1;
        }
        

    }

    public class AlgorithmRutishauser
    {
        // Сканирование строки -- разбиение на partOfString
        public List<string> ScanString(string str)
        {
            char[] digits = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            
            List<string> partsOfString = new List<string>();
            str = str.Replace(',', '.');
            str = str.Replace( " ", string.Empty);
            
            for (int i = 0; i < str.Length; i++)
            {
                
                char element = str[i];
                
                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || 
                    str[i] == '/' || str[i] == '(' || str[i] == ')' )
                {
                    partsOfString.Add(str[i].ToString());
                }
                
                if (digits.Contains(str[i]))
                {
                    string number = "";
                    while (digits.Contains(str[i]) || str[i] == '.')
                    {
                        number += str[i];
                        i++;
                    }

                    i--;
                    partsOfString.Add(number);
                }
            }
            
            
            return partsOfString;
        }

        // Строим список (часть строки -- уровень)
        public StructurList<MyStruct> ArithmeticExpression(List<string> partsOfString)
        {
            MyStruct[] data = {};
            
            StructurList<MyStruct> list = new StructurList<MyStruct>(data);

            int lvl = 0;
            double n;
            
            foreach (var partOfString in partsOfString)
            {
                if (partOfString == "("  || Double.TryParse(partOfString, out n))
                {
                    lvl++;
                    MyStruct myObject = new MyStruct();
                    myObject.Lvl = lvl;
                    myObject.PartOfString = partOfString;
                    
                    list.Add(myObject);
                }

                if (partOfString == ")" || partOfString == "+" ||
                    partOfString == "-" || partOfString == "*" ||
                    partOfString == "/")
                {
                    lvl--;
                    MyStruct myObject = new MyStruct();
                    myObject.Lvl = lvl;
                    myObject.PartOfString = partOfString;
                    list.Add(myObject);
                }
                
            }

            return list;

        }

        public string Rutishauser(string str)
        {
            double n = -1;
            
            if (Double.TryParse(str, out n))
            {
                return n.ToString();
            }

            else
            {
                StructurList<MyStruct> list = ArithmeticExpression(ScanString(str));

                // Найдем максимальный уровень
                int max = 0;
                foreach (var element in list.data)
                {
                    if (element.Lvl > max)
                    {
                        max = element.Lvl;
                    }
                }

                // Найдем 2 элемента с максимальным уровнем
                MyStruct element1 = new MyStruct();
                element1.Lvl = -1;
                element1.PartOfString = "";
                
                MyStruct element2 = new MyStruct();
                element1.Lvl = -1;
                element1.PartOfString = "";
               
                int num = 0;
                foreach (var element in list.data)
                {
                    if (element.Lvl == max)
                    {
                        if (element1.Lvl == -1)
                        {
                            element1 = element;
                        }
                        else
                        {
                            element2 = element;
                            break;
                        }
                    }

                    num++;
                }

                // Номер операции (между двумя элементами)
                num--;
                string operation = list.data[num].PartOfString;

                // Результат операции
                double res = 0;
                double value1 = Double.Parse(element1.PartOfString);
                double value2 = Double.Parse(element2.PartOfString);
                if (operation == "+")
                {
                    res = value1 + value2;
                }

                if (operation == "-")
                {
                    res = value1 - value2;
                }

                if (operation == "*")
                {
                    res = value1 * value2;
                }

                if (operation == "/")
                {
                    res = value1 / value2;
                }

                //list.Remove(num);
                //list.Remove(num + 1);
                //list.Remove(num + 2);
               // list.Remove(num - 1);
               // list.Remove(num - 2);
                
                // Индекс скобки (
                int idx1 = str.IndexOf(element1.PartOfString, StringComparison.Ordinal) - 1;

                // Индекс скобки )
                int idx2 = str.IndexOf(element2.PartOfString, StringComparison.Ordinal) + (element2.PartOfString.Length) + 1;

                string substring = str.Substring(idx1, idx2 - idx1);

                var regex = new Regex(Regex.Escape(substring));
                str = regex.Replace(str, res.ToString(CultureInfo.InvariantCulture), 1);

                return Rutishauser(str);
            }

        }

    }


}