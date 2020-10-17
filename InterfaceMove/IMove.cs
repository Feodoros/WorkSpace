using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    interface IMove
    {        
        int Velocity { get; set; }

        string MoveSound { get; set; }

        /// <summary>
        /// То, с помощью чего двигается
        /// </summary>
        string VelocityEngine { get; set; }

        string MakeSound();
    }
}
