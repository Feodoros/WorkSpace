using System;
using System.Collections.Generic;
using System.Text;

namespace CarInterface
{
    class Person : IMovable
    {
        public event IMovable.MoveHandler MoveEvent;

        void IMovable.Move()
        {
            Console.WriteLine("Идем пешком");
        }
    }
}
