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
        public List<Location> potentialPlanetLocations = new List<Location>();
        public List<Planet> planets = new List<Planet>();
        public Random r = new Random();
        public Player player;

        public void GenerateNewData()
        {
            GenerateRandomAsset();
        }

        public void Load()
        {

        }

        public void CreateCharacter(Player p)
        {
            player = p;
        }

        public void GenerateRandomAsset()
        {
            RandomAssetGenerator r = new RandomAssetGenerator();
            int radius = 7;
            int sectionSizeX = 70;
            int sectionSizeY = 50;
            int splitFactor = 4;
            RandomPlanetGenerationScope scope = new RandomPlanetGenerationScope(new XYPair(sectionSizeX, sectionSizeY),
                splitFactor, radius, 40);
            potentialPlanetLocations = r.GeneratePlanetLocations(scope);

            // BitMap for debug
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
