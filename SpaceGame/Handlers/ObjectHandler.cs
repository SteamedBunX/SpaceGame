using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class ObjectHandler
    {
        public Pages page = new Pages();
        public List<Location> potentialPlanetLocations = new List<Location>();
        public List<Planet> planets = new List<Planet>();
        public Random r = new Random();
        public Player player;

        public void Ini()
        {
            GenerateRandomAsset();
            Console.Write("Please enter your player's name: ");
            string playerName = Console.ReadLine();
            foreach (Location l in potentialPlanetLocations)
            {
                planets.Add(new Planet(l, "name"));
            }
            Planet currentPlanet = planets[r.Next(planets.Count - 1)];
            player = new Player(playerName, currentPlanet);
        }

        public void GenerateRandomAsset()
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
