using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGame;

namespace SpaceGame
{
    class Calc
    {
        public static bool withinDistance(Coordi c1, Coordi c2, int r)
        {
            return c1-c2 < r;
        }
    }
}
