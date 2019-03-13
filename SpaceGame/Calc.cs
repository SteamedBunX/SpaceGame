using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Calc
    {
        public static bool withinDistance(int x1, int y1, int x2, int y2, int r)
        {
            double radius = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return (radius - r) < 0;
        }

        public static bool withinDistance(Location l1, Location l2, int r)
        {
            return withinDistance(l1.getX(),l1.getY(),l2.getX(),l2.getY(), r);
        }
    }
}
