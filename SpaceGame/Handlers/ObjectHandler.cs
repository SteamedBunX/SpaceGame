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
            potentialPlanetLocations = assetG.EmptySpaceForHomeTown(potentialPlanetLocations, homeTownPosition);
            System.Threading.Thread.Sleep(2000);

            PrintGenerationInfo("Acquiring HomeTown Planet Names...");
            planets.AddRange(assetG.GenerateHomeTown(homeTownPosition));
            System.Threading.Thread.Sleep(2000);

            PrintGenerationInfo("Acquiring Planet Names...");
            planets.AddRange(assetG.PopulateLocation(potentialPlanetLocations));
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


        public void PrintGenerationInfo(string info)
        {
            Console.Clear();
            FreeString content = new FreeString(25, info);
            content.Print();
        }
    }
}
