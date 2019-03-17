using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Player
    {
        string name;
        Gender gender;
 //       Location location;
        Planet currentPlanet;
        public Player(string n, Gender g)
        {
            name = n;
            gender = g;
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
