using System;

namespace CarInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person person = new Person();
            Car car = new Car();

            Action(person);
            Action(car);


        }

        static void Action(IMovable movable)
        {
            movable.Move();
        }
    }
}
