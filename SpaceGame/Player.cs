using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Player
    {
        string name;
        Location location;
        public Player(string n, Location l)
        {
            name = n;
            location = l;
        }

        public void setLocation(Location l)
        {
            location.updateLocation(l);
        }

        public void printCurrentStatus()
        {
            Console.WriteLine($"{name} is current at the location :{location}");
        }

    }
}
