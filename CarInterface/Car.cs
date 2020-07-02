using System;
using System.Collections.Generic;
using System.Text;

namespace CarInterface
{
    internal class Car : IMovable
    {
        public event IMovable.MoveHandler MoveEvent;

        public void Boost()
        {
            Console.WriteLine("Ускоряемся на машине.");
        }

        public void Move()
        {
            Console.WriteLine("Едим на машине.");
        }

    }
}
