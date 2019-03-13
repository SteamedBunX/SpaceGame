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
        List<Location> potentialPlanetLocations = new List<Location>();
        List<Planet> planets = new List<Planet>();
        Random r = new Random();
        Player player;
        public void ini()
        {
            Console.Write("Please enter your player's name: ");
            string playerName = Console.ReadLine();
            foreach(Location l in potentialPlanetLocations)
            {
                planets.Add(new Planet(l, "name"));
            }
            Planet currentPlanet = planets[r.Next(planets.Count - 1)];
            player = new Player(playerName, currentPlanet);
        }

        public void run()
        {

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"You are current at the location: {player.GetCurrentPlanet().GetLocation()}");
                List<Planet> accessablePlanet = new List<Planet>();
                int accessableR = 18;
                Console.WriteLine("Current accessable planets are as follow: ");
                int count = 0;
                foreach (Planet p in planets)
                {
                    if (Calc.withinDistance(p.GetLocation(), player.GetCurrentPlanet().GetLocation(), accessableR) 
                        && p.GetLocation() != player.GetCurrentPlanet().GetLocation())
                    {
                        count++;
                        accessablePlanet.Add(p);
                        Console.WriteLine($"{count}. {p.GetLocation()}");
                    }
                }
                Console.Write("Please enter the index of the planet you would like to move to");
                int index = int.Parse(Console.ReadLine());
                player.setPlanet(accessablePlanet[index - 1]);
            }
        }

        public void generateRandomAsset()
        {
            RandomAssetGenerator r = new RandomAssetGenerator();
            int radius = 4;
            int sectionSizeX = 50;
            int sectionSizeY = 30;
            int splitFactor = 4;
            potentialPlanetLocations = r.GeneratePlanetLocations(sectionSizeX, sectionSizeY, splitFactor, radius, 40);
            Console.WriteLine(potentialPlanetLocations.Count);
            Console.ReadLine();
            Bitmap bmp = new Bitmap((sectionSizeX + radius) * splitFactor * 10, (sectionSizeY + radius) * splitFactor * 10);
            Graphics g = Graphics.FromImage(bmp);
            foreach (Location l in potentialPlanetLocations)
            {
                g.DrawEllipse(new Pen(Color.Black, 3f),
                    new Rectangle(new Point((l.getX() - radius) * 10, (l.getY() - radius) * 10), new Size(radius * 10, radius * 10)));
            }
            g.Dispose();
            bmp.Save(@"C:\MSSA\Test.PNG", System.Drawing.Imaging.ImageFormat.Png);
            bmp.Dispose();
        }
    }
}
