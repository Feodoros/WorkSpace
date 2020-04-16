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
    public struct MyStruct
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
        
        // Добавление (в конец или на позицию)
        public void Add(T element, int idx = -1)
        {
            int n = Count();
            T[] dataNew= new T[n + 1];
            if(idx == -1)
            {
                for (int i = 0; i < n; i++)
                {
                    dataNew[i] = data[i];
                }

                dataNew[n] = element;

                data = dataNew;
            }
            else
            {
                bool flag = true;
                for (int i = 0; i < n + 1; i++)
                {
                    if (idx != i && flag)
                    {
                        dataNew[i] = data[i];
                    }
                    else
                    {
                        if (flag)
                        {
                            flag = false;
                            dataNew[i] = element;
                        }
                        else
                        {
                            dataNew[i] = data[i-1];
                        }
                    }
                }
                
            }

            data = dataNew;
        }
        
        // Удаление элемента
        public void Remove(int index)
        {
            int n = Count();
            T[] dataNew = new T[n-1];

            bool flag = true;
            
            if (index == n - 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    dataNew[i] = data[i];
                }
            }

            else
            {
                for (int i = 0; i < n-1; i++)
                {
                    if (index != i && flag)
                    {
                        dataNew[i] = data[i];
                    }

                    else
                    {
                        flag = false;
                        dataNew[i] = data[i + 1];
                    }
                }
            }
            
            data = dataNew;
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

        // Алгоритм Рутисхаузера
        public string Rutishauser(string str)
        {
            if (!IsBalanced(str))
            {
                return "Скобочная структура неверна!";
            }
            
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

                list.Remove(num - 2);
                list.Remove(num - 2);
                list.Remove(num - 2);
                list.Remove(num - 2);
                list.Remove(num - 2);
                
                MyStruct newRes = new MyStruct();
                newRes.PartOfString = res.ToString(CultureInfo.InvariantCulture);
                newRes.Lvl = max - 1;
                
                list.Add(newRes, num - 2);

                str = "";
                foreach (var element in list.data)
                {
                    str += element.PartOfString;
                }
                
                return Rutishauser(str);
            }

        }
        
        static bool IsBalanced(string s)
        {    
            Stack<char> stackBrackets = new Stack<char>();
                
            // Все возможные скобки
            string brackets = "{[(";
            
            // Инверсируем все скобки
            string str = s.Replace(')', '(').Replace(']', '[').Replace('}', '{');
            
            // Новая строка, содержащая только открывающие скобки
            var newString = str.Where(c => brackets.Contains(c));

            foreach (char c in newString)
            {
                if (stackBrackets.Count == 0 || stackBrackets.Peek() != c)
                    stackBrackets.Push(c);
                else 
                    stackBrackets.Pop();
            }
            
            return stackBrackets.Count == 0;
        }

    }


}