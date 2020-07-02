using System;

namespace CarInterface
{
    class Program
    {
        static void Main(string[] args)
        {            
            Person person = new Person();
            Car car = new Car();

            Action(person);
            Action(car);

            Console.ReadLine();
        }

        static void Action(IMovable movable)
        {
            movable.Move();
        }
    }
}
