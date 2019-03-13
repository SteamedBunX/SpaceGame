using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomAssetGenerator r = new RandomAssetGenerator();
            int radius = 4;
            int sectionSizeX = 50;
            int sectionSizeY = 30;
            int splitFactor = 4;
            List<Location> planetLocations = r.GeneratePlanetLocations(sectionSizeX, sectionSizeY, splitFactor, radius, 40);
            Console.WriteLine(planetLocations.Count);
            Console.ReadLine();
            Bitmap bmp = new Bitmap((sectionSizeX+radius)*splitFactor*10, (sectionSizeY + radius) * splitFactor * 10);
            Graphics g = Graphics.FromImage(bmp);
            foreach(Location l in planetLocations)
            {
                g.DrawEllipse(new Pen(Color.Black,3f),
                    new Rectangle(new Point((l.getX()- radius) *10, (l.getY()- radius) *10), new Size(radius*10, radius*10)));
            }
            g.Dispose();
            bmp.Save(@"C:\MSSA\Test.PNG", System.Drawing.Imaging.ImageFormat.Png);
            bmp.Dispose();
        }
    }
}
