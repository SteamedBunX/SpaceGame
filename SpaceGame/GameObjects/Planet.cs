using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Planet
    {
        string name;
        Location location;
//        bool generated;
        public Planet(Location l, string n)
        {
            name = n;
            location = l;
        }

        public Location GetLocation()
        {
            return location;
        }
    }
}
