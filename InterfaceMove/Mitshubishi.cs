using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMove
{
    class Mitshubishi : Car
    {
        public Mitshubishi(int velocity, string moveSound, string velocityengine) : base(velocity, moveSound, velocityengine)
        {           
        }

        public override string MakeSound()
        {
            return "Митсубиши делает " + MoveSound;
        }
    }
}
