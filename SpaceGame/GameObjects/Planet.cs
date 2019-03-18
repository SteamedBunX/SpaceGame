using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Planet
    {
        public string name;
        public Location location;
        public bool loaded;
//        bool generated;
        public Planet(Location l, string n)
        {
            name = n;
            location = l;
        }

        public Planet(Coordi l, string n)
        {
            name = n;
            location = new Location(l);
        }

        public string GetName()
        {
            return name;
        }

        public Location GetLocation()
        {
            return location;
        }
    }
}
