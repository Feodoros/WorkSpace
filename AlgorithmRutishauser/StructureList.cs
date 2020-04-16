using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AlgorithmRutishauser
{
    // Тип данных
    public struct MyStruct
    {
        public string PartOfString { get; set; }
        public int Lvl { get; set; }
    }

    // Свой список
    public class StructureList<T> : IEnumerable<T>
    {
        public T[] Data;
        
        public StructureList(T[] data)
        {
            this.Data = data;
        }
        
        // индексатор
        public T this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        public int Count()
        {
            return Data.Length;
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
                    dataNew[i] = Data[i];
                }

                dataNew[n] = element;

                Data = dataNew;
            }
            else
            {
                bool flag = true;
                for (int i = 0; i < n + 1; i++)
                {
                    if (idx != i && flag)
                    {
                        dataNew[i] = Data[i];
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
                            dataNew[i] = Data[i-1];
                        }
                    }
                }
                
            }

            Data = dataNew;
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
                    dataNew[i] = Data[i];
                }
            }

            else
            {
                for (int i = 0; i < n-1; i++)
                {
                    if (index != i && flag)
                    {
                        dataNew[i] = Data[i];
                    }

                    else
                    {
                        flag = false;
                        dataNew[i] = Data[i + 1];
                    }
                }
            }
            
            Data = dataNew;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T current = Data[0];
            int i = 0;
            
            // ReSharper disable once PossibleNullReferenceException
            while (!default(T).Equals(current))
            { 
                yield return current;
                if(i + 1 != Count())
                {
                    current = Data[i+1];
                    i++;
                }
                else
                {
                    current = default(T);
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }

    public static class AlgorithmRutishauser
    {
        // Алгоритм Рутисхаузера
        public static string Rutishauser(string str)
        {
            double n = -1;
            
            if (Double.TryParse(str, out n))
            {
                return n.ToString(CultureInfo.InvariantCulture);
            }
            
            if (!IsBalanced(str))
            {
                return "Скобочная структура неверна!";
            }
            
            if (!CheckCorrectStr(str))
            {
                return "Ошибка в составлении выражения! (Расположите каждое действие в отдельных скобках)";
            }
            
            else
            {
                StructureList<MyStruct> list = ScanArithmeticExpression(str);

                list = DeterminateExpression(list);
                
                str = "";
                foreach (var element in list)
                {
                    str += element.PartOfString;
                }

                str = str.Replace('.', ',');
                return Rutishauser(str);
            }

        }

        #region Helpers

        // Строим список [partOfString -- Lvl]
        static StructureList<MyStruct> ScanArithmeticExpression(string str)
        {
            char[] digits = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            str = str.Replace('.', ',');
            str = str.Replace( " ", string.Empty);
            
            MyStruct[] data = {};
            StructureList<MyStruct> list = new StructureList<MyStruct>(data);
            int lvl = 0;
            
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == '(')
                {
                    lvl++;
                    list.Add(new MyStruct { PartOfString = str[i].ToString(), Lvl = lvl});
                }
                
                if (digits.Contains(str[i]))
                {
                    string number = "";
                    while (digits.Contains(str[i]) || str[i] == ',')
                    {
                        number += str[i];
                        i++;
                    }

                    i--;
                    
                    lvl++;
                    list.Add(new MyStruct { PartOfString = number, Lvl = lvl});
                }

                if (str[i] == '+' || str[i] == '-' || str[i] == '*' ||
                    str[i] == '/' || str[i] == ')')
                {
                    lvl--;
                    list.Add(new MyStruct { PartOfString = str[i].ToString(), Lvl = lvl});
                }
            }

            return list;
        }
        
        // Найдем максимальный уровень
        static int GetMaxLvl(StructureList<MyStruct> list)
        {
            int max = 0;
            foreach (var element in list.Data)
            {
                if (element.Lvl > max)
                {
                    max = element.Lvl;
                }
            }

            return max;
        }
        
        // Вычислить значение к скобках
        static StructureList<MyStruct> DeterminateExpression(StructureList<MyStruct> list)
        {
            // Найдем 2 элемента с максимальным уровнем
            int max = GetMaxLvl(list);
            
            MyStruct element1 = new MyStruct();
            element1.Lvl = -1;
            element1.PartOfString = "";
            
            MyStruct element2 = new MyStruct();
            element1.Lvl = -1;
            element1.PartOfString = "";

            int num = 0;
            
            foreach (var element in list)
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
            string operation = list.Data[num].PartOfString;

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
                res = Math.Round(value1 / value2, 3);
            }

            list.Remove(num - 2);
            list.Remove(num - 2);
            list.Remove(num - 2);
            list.Remove(num - 2);
            list.Remove(num - 2);

            MyStruct newRes = new MyStruct {PartOfString = res.ToString(CultureInfo.InvariantCulture), Lvl = max - 1};

            list.Add(newRes, num - 2);

            return list;
        }

        #endregion
        
        #region Errors
        
        // Проверка скобочной структуры
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

        // Проверка, что ровно 2 элемента с макс уровнем
        static bool CheckCorrectStr(string str)
        {
            StructureList<MyStruct> list = ScanArithmeticExpression(str);
            int max = GetMaxLvl(list);
            int count = 0;
            foreach (var element in list.Data)
            {
                if (element.Lvl == max)
                    count++;
            }

            return count == 2;
        }
        
        #endregion
    }
}