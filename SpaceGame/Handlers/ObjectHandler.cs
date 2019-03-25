using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class ObjectHandler
    {
        public Random r = new Random();
        string categoryPath = Environment.CurrentDirectory + @"\Datas\Category.data";
        public bool initiated = false;

        public void Ini()
        {
            LoadImages();
            LoadCategoryDatas();
            
        }

        string itemPath = Environment.CurrentDirectory + @"\Datas\Item.data";

        public ImageHandler images = new ImageHandler();

        public List<CategoryData> categoryDatas = new List<CategoryData>();

        public Player player;
        public List<Planet> planets = new List<Planet>();

        public void LoadImages()
        {
            string imageFolderPath = Environment.CurrentDirectory + @"\Images\";
            images.LoadImages(imageFolderPath);
        }

        public void LoadCategoryDatas()
        {
            StreamReader categories = new StreamReader(categoryPath);

            do
            {
                string[] nextLine = categories.ReadLine().Split(':');
                categoryDatas.Add(new CategoryData(int.Parse(nextLine[0]), nextLine[1],
                    double.Parse(nextLine[2]), double.Parse(nextLine[3])));
            } while (!categories.EndOfStream);
            LoadItemDatas();
        }

        public void LoadItemDatas()
        {
            StreamReader items = new StreamReader(itemPath);

            do
            {
                string[] nextLine = items.ReadLine().Split(':');
                int categoryIndex = int.Parse(nextLine[0]);
                categoryDatas.FirstOrDefault(c => c.index == categoryIndex).
                    AddItem(int.Parse(nextLine[1]), nextLine[2],
                    int.Parse(nextLine[3]), double.Parse(nextLine[4]));
            } while (!items.EndOfStream);
        }

        public void PrintImage(XYPair position, string imageName)
        {

            images.Print(position, imageName);
        }

        public void GenerateNewData()
        {
            GenerateNewGalaxy();
            initiated = true; 
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
            List<XYPair> potentialPlanetLocations = assetG.GeneratePlanetLocations(scope);
            System.Threading.Thread.Sleep(1000);

            PrintGenerationInfo("Locating Home Planet System...");
            XYPair homeTownPosition = new XYPair(r.Next(50, 230), r.Next(50, 140));
            potentialPlanetLocations = assetG.EmptySpaceForHomeTown(potentialPlanetLocations, homeTownPosition);
            System.Threading.Thread.Sleep(1000);

            PrintGenerationInfo("Acquiring HomeTown Planet Names...");
            planets.AddRange(assetG.GenerateHomeTown(homeTownPosition));
            System.Threading.Thread.Sleep(1000);

            PrintGenerationInfo("Acquiring Planet Names...");
            planets.AddRange(assetG.PopulateLocation(potentialPlanetLocations));
            System.Threading.Thread.Sleep(1000);

            PrintGenerationInfo("Analyzing Market Data...");
            foreach (Planet p in planets)
            {
                p.GenerateMarket(ref r, categoryDatas);
                p.RefreshFuelPrice(ref r);
            }
            System.Threading.Thread.Sleep(1000);

            PrintGenerationInfo($"Locating {player.GetName()}...");
            player.setPlanet(planets.Find(p => p.GetName() == "Earth"));
            System.Threading.Thread.Sleep(1000);


            PrintGenerationInfo($"Generating Galaxy Map...");
            // BitMap for debug
            Bitmap bmp = new Bitmap((sectionSizeX + radius) * splitFactor * 10, (sectionSizeY + radius) * splitFactor * 10);
            Graphics g = Graphics.FromImage(bmp);
            foreach (XYPair l in potentialPlanetLocations)
            {
                g.DrawEllipse(new Pen(Color.FromArgb(12,12,12), 3f),
                    new Rectangle(new Point((l.x - radius) * 10, (l.y - radius) * 10), new Size(radius * 10, radius * 10)));
            }
            List<String> homePlanets = new List<string> { "Earth", "Mars", "XCentrolStation", "YoRHa", "Ernasis", "Alpha Centauri 3",
             "Lisnar", "Amenias", "Agnesia"};
            foreach (Planet p in planets)
            {
                if (homePlanets.Contains(p.name))
                {
                    g.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#ff00ffff")), new Rectangle(new Point((p.GetLocation().x - radius) * 10, (p.GetLocation().y - radius) * 10),
                    new Size(radius * 2, radius * 2))
                    );
                }

            }

            g.Dispose();
            bmp.Save(@"C:\MSSA\Galaxy Map.PNG", System.Drawing.Imaging.ImageFormat.Png);
            bmp.Dispose();
            PrintGenerationInfo($"Process Complete!");
            System.Threading.Thread.Sleep(3000);
            PrintGenerationInfo($"Welcome, {player.name}!");
            System.Threading.Thread.Sleep(2000);
        }


        public void PrintGenerationInfo(string info)
        {
            Console.Clear();
            FreeString content = new FreeString(25, info);
            content.Print();
        }
    }
}
