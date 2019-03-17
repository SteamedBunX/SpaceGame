using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class ObjectHandler
    {
        public Pages page = new Pages();
        public List<Planet> planets = new List<Planet>();
        public Random r = new Random();
        public Player player;

        public void GenerateNewData()
        {
            GenerateNewGalaxy();
        }

        public void Load()
        {

        }

        public void SetPlayerCharacter(Player p)
        {
            player = p;
        }

        public void GenerateNewGalaxy()
        {
            AssetGenerator assetG = new AssetGenerator();
            int radius = 7;
            int sectionSizeX = 70;
            int sectionSizeY = 50;
            int splitFactor = 4;//280 by 200
            RandomPlanetGenerationScope scope = new RandomPlanetGenerationScope(new XYPair(sectionSizeX, sectionSizeY),
                splitFactor, radius, 40);

            PrintGenerationInfo("Locating Planets...");
            List<Location> potentialPlanetLocations = assetG.GeneratePlanetLocations(scope);
            System.Threading.Thread.Sleep(2000);

            PrintGenerationInfo("Locating Home Planet System...");
            Coordi homeTownPosition = new Coordi(r.Next(50, 230), r.Next(50, 140));
            potentialPlanetLocations = EmptySpaceForHomeTown(potentialPlanetLocations, homeTownPosition);
            System.Threading.Thread.Sleep(2000);

            PrintGenerationInfo("Acquiring HomeTown Planet Names...");
            planets.AddRange(GenerateHomeTown(homeTownPosition));
            System.Threading.Thread.Sleep(2000);

            PrintGenerationInfo("Acquiring Planet Names...");
            planets.AddRange(PopulateLocation(potentialPlanetLocations));
            System.Threading.Thread.Sleep(2000);

            PrintGenerationInfo($"Locating {player.GetName()}...");
            player.setPlanet(planets.Find(p => p.GetName() == "Earth"));
            System.Threading.Thread.Sleep(2000);


            PrintGenerationInfo($"Generating Galaxy Map...");
            // BitMap for debug
            Bitmap bmp = new Bitmap((sectionSizeX + radius) * splitFactor * 10, (sectionSizeY + radius) * splitFactor * 10);
            Graphics g = Graphics.FromImage(bmp);
            foreach (Location l in potentialPlanetLocations)
            {
                g.DrawEllipse(new Pen(Color.Black, 3f),
                    new Rectangle(new Point((l.getX() - radius) * 10, (l.getY() - radius) * 10), new Size(radius * 10, radius * 10)));
            }
            g.Dispose();
            bmp.Save(@"C:\MSSA\Galaxy Map.PNG", System.Drawing.Imaging.ImageFormat.Png);
            bmp.Dispose();
            PrintGenerationInfo($"Process Complete! Welcome, {player.name}.");
            Console.ReadLine();
        }

        public List<Location> EmptySpaceForHomeTown(List<Location> potentialPlanetLocations, Coordi homeTown)
        {
            potentialPlanetLocations.RemoveAll(l => (l.getX() > homeTown.x && l.getX() < homeTown.x + 12)
                                                && (l.getY() > homeTown.y && l.getY() < homeTown.y + 12));
            return potentialPlanetLocations;
        }

        public List<Planet> PopulateLocation(List<Location> potentialPlanetLocations)
        {
            List<Planet> randomPlanets = new List<Planet>();
            int x = 1;
            foreach (Location l in potentialPlanetLocations)
            {
                randomPlanets.Add(new Planet(l, $"Planet{x}"));
                x++;
            }
            return randomPlanets;
        }

        public List<Planet> GenerateHomeTown(Coordi homeTown)
        {
            int x = homeTown.x;
            int y = homeTown.y;
            List<Planet> homeTownPlanets = new List<Planet>();
            homeTownPlanets.Add(new Planet(new Coordi(5 + x, 5 + y), "Earth"));
            homeTownPlanets.Add(new Planet(new Coordi(4 + x, 3 + y), "Mars"));
            homeTownPlanets.Add(new Planet(new Coordi(5 + x, 4 + y), "XCentrolStation"));
            homeTownPlanets.Add(new Planet(new Coordi(4 + x, 5 + y), "YoRHa"));
            homeTownPlanets.Add(new Planet(new Coordi(7 + x, 8 + y), "Ernasis"));
            homeTownPlanets.Add(new Planet(new Coordi(10 + x, 10 + y), "Alpha Centauri 3"));
            homeTownPlanets.Add(new Planet(new Coordi(0 + x, 2 + y), "Lisnar"));
            homeTownPlanets.Add(new Planet(new Coordi(1 + x, 8 + y), "Amenias"));
            homeTownPlanets.Add(new Planet(new Coordi(9 + x, 2 + y), "Agnesia"));

            return homeTownPlanets;
        }

        public void PrintGenerationInfo(string info)
        {
            Console.Clear();
            FreeString content = new FreeString(25, info);
            content.Print();
        }
    }
}
