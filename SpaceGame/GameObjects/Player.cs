using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Player
    {
        public string name;
        public Gender gender;
        public Planet currentPlanet;
//      Location location;

        public Player(string n, Gender g)
        {
            name = n;
            gender = g;
        }

        public string GetName()
        {
            return name;
        }

        public void setPlanet(Planet p)
        {
            currentPlanet = p;
        }

        public void printCurrentStatus()
        {
            Console.WriteLine($"{name} is current at the location :{currentPlanet.GetLocation()}");
        }

        public Planet GetCurrentPlanet()
        {
            return currentPlanet;
        }

    }
}
