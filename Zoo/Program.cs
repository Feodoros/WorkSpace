using System;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal(12, "dsds", 112);

            Beast beast1 = new Beast(13, "Male", "Alpha", 12, "White", "Wolf");
            
            beast1.GetInfo();
            
            Bird bird1 = new Bird(2, "Female", 1, 6, 110);
            bird1.GetInfo();
            
            Carp carp1 = new Carp(10, "Male", 4, "Sea", 7);
            carp1.GetInfo();
            carp1.GetFishInfo();
            
            Shark shark1 = new Shark(10, "Male", 4, "River");
            shark1.GetFishInfo();
            
            
            
            /// ДЗ:
            /// Создать зоопарк: 4 разных животных, 11 разных рыб, 5 разных птиц.
            /// Найти имя старшего животного
            /// Отсортировать птиц по времени полета по возрастанию и по убыванию по размеру крыла
            /// Отобразить всех морских карпов карпов (всю инфу вывести)
            /// Beast class сделать абстрактным и сделать 2 его наследника (e.x. Wolf, Elephant) с какими-то полями  
        }
    }
}