using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList() {1, 2, 'a', 1.0, "string"};
            arrayList.Add(1.0);
            arrayList.AddRange(new int[] {2, 3, 4, 5});
            arrayList.Insert(1, 1.0);
            arrayList[1] = 1.0;
            
            foreach (object element in arrayList)
            {
                Console.WriteLine(element);
            }
            
            
            List<int> list = new List<int>(){1, 2, 3, 4};
            list.AddRange(new int[] {5, 6, 7});
            list.Add(1);
            list.FindAll(x => x % 2 == 0);
            
            List<Person> persons = new List<Person>();
            persons.Add(new Person() {Name = "Иван"});
            
            LinkedList<char> linkedList = new LinkedList<char>();
            linkedList.AddLast('c');
            linkedList.AddFirst('a');
            linkedList.AddAfter(linkedList.First, 'b');
            
            
            // FIFO -- First In First Out
            Queue<int> queue = new Queue<int>();
            
            // Добавялем в конец очереди
            queue.Enqueue(1); 
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            // Извлекаем первый элемент из очереди
            int queueItem = queue.Dequeue(); // 1
            int queueItem1 = queue.Dequeue(); // 2    
            int item = queue.Peek();
            
            
            
            // LIFO -- Last In First Out
            Stack<string> colorsBalls = new Stack<string>();
            
            // Добавляем в начало (пример коробка с шарами)
            colorsBalls.Push("red");
            colorsBalls.Push("yellow");
            colorsBalls.Push("green");
            
            // Извлекаем и возвращаем первый элемент
            string firstColorBall = colorsBalls.Pop(); // green
            
            
            Dictionary<int, string> names = new Dictionary<int, string>(3);
            names.Add(1, "Ivan");
            names.Add(2, "Ivan");
            names.Add(101, "Alexey");
            string name = names[101]; // Получение элемента по ключу
            names.Remove(2); // Удаляем эллемент с ключом 2
            names[1] = "Nikita"; // Меняем элемент с ключом 1

            string findName = "Alexey";
            int key;
            foreach (KeyValuePair<int, string> keyValue in names)
            {
                if (keyValue.Value == findName)
                    key = keyValue.Key;
            }

            var selectKey = from kv in names where kv.Value == "Alexey" select kv.Key;

            foreach (int keyB in names.Keys)
            {
                Console.WriteLine(names[keyB]);
                
            }

            foreach (string value in names.Values)
            {
                Console.WriteLine(value);
            }
            
            
            Dictionary<string, string> capitals = new Dictionary<string, string>
            {
                {"Moscow", "Russia"},
                {"Paris", "France"},
                {"Washington", "USA"},
                {"SPb", "Russia"}
            };

            foreach (KeyValuePair<string, string> capital in capitals)
            {
                //Console.WriteLine($"{capital.Key} столица {capital.Value}");
            }
            
            
            // HomeWork
            // Задача 1.
            Dictionary<int, int> numbers = CreateDict(5);
            foreach (var keyValuePair in numbers)
            {
                Console.WriteLine($"{keyValuePair.Key} -- {keyValuePair.Value}");
            }
            
            // Задача 2.
            string s = "( { [ Hello, World! ] }  )";
            Console.WriteLine(IsBalanced(s));
            
            // Задача 3.
            QueueProcess();
            
        }

        static Dictionary<int, int> CreateDict(int N)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>(N);
            for (int i = 0; i < N; i++)
            {
                numbers.Add(i, i*i);
            }
            return numbers;
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
        
        static void QueueProcess()
        {
            Random r = new Random();
            Queue<int> queue = new Queue<int>();
            
            // Заполняем очередь
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(r.Next(1, 99));
            }

            while (queue.Count != 0 && queue.Peek() % 2 != 0)
                queue.Dequeue();

            if (queue.Count == 0)
                Console.WriteLine("Очередь не содержит четных чисел.");
            else
                foreach (var queueNumber in queue)
                {
                    Console.Write(queueNumber + " ");
                }
        }
        
        // ДЗ:
        //     1) Написать программу, составляющую словарь из ключ-значений, где
        //        key -- число, value -- квадрат ключа (key^2)
        //
        //     2) Написать программу, проверяющую строку на правильность 
        //        скобочной структуры (IsBalanced), используя класс Stack
        //
        //     3) Удалить из очереди (Queue<int>) все числа до первого четного числа.
        //        Очередь заполняется рандомно элементами от 1 до 99. 
        //        Количесвто элементов в очереди = 10. Если в очереди нет четных чисел,
        //        то возвращаем запись, что вся очередь обслужена (нет четных элементов).
        
        
    }

    class Person
    {

        public string Name { get; set; }

        public string SayName()
        {
            return this.Name;
        } 
    }
    
}