using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace PCFindSimilar
{
    class Program
    {
        static void Main(string[] args)
        {
    
                SHuman[] humans = {
                new SHuman("Верещагин", "Петр", "Петрович", 1834),
                new SHuman("Ломоносов", "Михаил", "Васильевич", 1711),
                new SHuman("Тютчев", "Фёдор", "Иванович", 1803),
                new SHuman("Суворов", "Александр", "Васильевич", 1729),
                new SHuman("Менделеев", "Дмитрий", "Иванович", 1834),
                new SHuman("Ахматова", "Анна", "Андреевна", 1889),
                new SHuman("Володин", "Александр", "Моисеевич", 1919),
                new SHuman("Мухина", "Вера", "Игнатьевна", 1889),
                new SHuman("Пушкин", "Александр", "Сергеевич", 1799)};
                
                List<List<SHuman>> groups = new List<List<SHuman>>();
                groups = RemoveCopies(Groupping(humans, groups));
                Console.WriteLine(groups);
        }

        public static List<List<SHuman>> Groupping(SHuman[] humans, List<List<SHuman>> groups)
        {
            bool newGroup = false;
            SHuman newHuman = new SHuman();
            
            // Создаем первую группу из первого человека из списка людей
            if (groups.Count == 0)
            {
                List<SHuman> group0 = new List<SHuman>();
                group0.Add(humans[0]);
                groups.Add(group0);
            }

            // Пробегаем по каждой группе, по каждому человеку в этой группе
            // И смотрим можем ли добавить в этй группу нового человека из списка
            foreach (var human in humans.ToList())
            {
                foreach (var group in groups.ToList())
                {
                    foreach (var humanInGroup in group.ToList())
                    {
                        // Добавляем в группу человека, если можем,
                        // Но смотрим не содержится ли он там уже
                        if (IsHumanEqual(human, humanInGroup))
                        {
                            if (!group.Contains(human))
                            {
                                group.Add(human);
                                newGroup = false;
                                Groupping(humans, groups);
                            }
                        }
                        
                        // Если его нельзя добавить в текущую группу, то запоминаем,
                        // Его, тк его мб сможем добавить в другую группу, до
                        // Которой еще не дошли
                        else
                        {
                            newGroup = true;
                            newHuman = human;
                        }
                    }
                }
                
                // Проверяем есть ли этот человек в уже какой-то группе
                foreach (var group in groups.ToList())
                {
                    if (group.Contains(human))
                        newGroup = false;
                }
                
                // Создаем новую группу и добавляем туда человека
                if (newGroup)
                {
                    List<SHuman> @group = new List<SHuman>();
                    group.Add(newHuman);
                    groups.Add(group);
                    Groupping(humans, groups);
                }
            }
            
            return groups;
        }

        public static bool IsHumanEqual(SHuman human, SHuman human0)
        {
            return ((human.Firstname == human0.Firstname || human.Surname == human0.Surname ||
                    human.Patronymic == human0.Patronymic || human.Year == human0.Year) &&
                    !(human.Firstname == human0.Firstname && human.Surname == human0.Surname &&
                     human.Patronymic == human0.Patronymic && human.Year == human0.Year));
            
        }

        public static List<List<SHuman>> RemoveCopies(List<List<SHuman>> groups)
        {
            // Добавляем по представителю из каждой группы в список
            // И потом строим пересечение этого списка с каждой группой
            // Если пересечение не пустое, то группа с этим человеком 
            // Уже добавлена 
            List<List<SHuman>> newList = new List<List<SHuman>>(groups.Count);
            List<SHuman> delegateSHumans = new List<SHuman>();
            
            foreach (var group in groups)
            {
                if (!delegateSHumans.Intersect(group).Any())
                {
                    delegateSHumans.Add(group[0]);
                    newList.Add(group);
                }
            }
            
            return newList;
        }
        public struct SHuman
        {
            public string Surname;
            public string Firstname;
            public string Patronymic;
            public int Year;

            public SHuman(string surname, string firstname, string patronymic, int year)
            {
                Surname = surname;
                Firstname = firstname;
                Patronymic = patronymic;
                Year = year;
            }
        }
    }
}