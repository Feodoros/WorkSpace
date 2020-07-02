using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CarInterface
{
    interface IMovable
    {
        const int minSpeed = 0;
        static int maxSpeed = 15;

        public void Move();

        public void Boost(); 
       
        delegate void MoveHandler(string message);

        event MoveHandler MoveEvent;
    }
}
