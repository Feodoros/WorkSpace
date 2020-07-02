using System;
using System.Collections.Generic;
using System.Text;

namespace CarInterface
{
    class Person : IMovable
    {
        public event IMovable.MoveHandler MoveEvent;

        public void Boost()
        {
            Console.WriteLine("Ускоряемся пешком");
        }

        public void Move()
        {
            Console.WriteLine("Идем пешком");
        }
    }
}
