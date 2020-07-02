using System;
using System.Collections.Generic;
using System.Text;

namespace CarInterface
{
    internal class Car : IMovable
    {
        public event IMovable.MoveHandler MoveEvent;

        void IMovable.Move()
        {
            Console.WriteLine("Едим на машине.");
        }
    }
}
