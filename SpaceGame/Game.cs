using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Game
    {

        ObjectHandler obs = new ObjectHandler();

        public void Ini()
        {
            obs.Ini();
        }

        public void Run()
        {

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"You are current at the location: {obs.player.GetCurrentPlanet().GetLocation()}");
                List<Planet> accessablePlanet = new List<Planet>();
                int accessableR = 18;
                Console.WriteLine("Current accessable planets are as follow: ");
                int count = 0;
                foreach (Planet p in obs.planets)
                {
                    if (Calc.withinDistance(p.GetLocation(), obs.player.GetCurrentPlanet().GetLocation(), accessableR) 
                        && p.GetLocation() != obs.player.GetCurrentPlanet().GetLocation())
                    {
                        count++;
                        accessablePlanet.Add(p);
                        Console.WriteLine($"{count}. {p.GetLocation()}");
                    }
                }
                Console.Write("Please enter the index of the planet you would like to move to");
                int index = int.Parse(Console.ReadLine());
                obs.player.setPlanet(accessablePlanet[index - 1]);
            }
        }


    }
}
