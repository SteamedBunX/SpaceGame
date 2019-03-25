using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class AssetGenerator
    {
        Random r = new Random();



        // generate planet
        public List<Planet> planets = new List<Planet>();

        public ObjectHandler GetDefaultObjectHandler()
        {

            ObjectHandler objH = new ObjectHandler();
            objH.LoadImages();
            objH.SetPlayerCharacter(new Player("TestSubject", Gender.Female, ref objH));
            objH.player.money = 100000;
            objH.planets.AddRange(GenerateHomeTown(new XYPair(0, 0)));
            objH.player.setPlanet(objH.planets.FirstOrDefault(p => p.name == "Earth"));
            objH.LoadCategoryDatas();
            foreach (Planet p in objH.planets)
            {
                p.GenerateMarket(ref r, objH.categoryDatas);
            }
            return objH;
        }







        public List<Planet> GenerateHomeTown(XYPair homeTown)
        {
            int x = homeTown.x;
            int y = homeTown.y;
            List<Planet> homeTownPlanets = new List<Planet>();
            homeTownPlanets.Add(new Planet(new XYPair(5 + x, 5 + y), "Earth"));
            homeTownPlanets.Add(new Planet(new XYPair(4 + x, 3 + y), "Mars"));
            homeTownPlanets.Add(new Planet(new XYPair(5 + x, 4 + y), "XCentrolStation"));
            homeTownPlanets.Add(new Planet(new XYPair(4 + x, 5 + y), "YoRHa"));
            homeTownPlanets.Add(new Planet(new XYPair(7 + x, 8 + y), "Ernasis"));
            homeTownPlanets.Add(new Planet(new XYPair(9 + x, 9 + y), "Alpha Centauri 3"));
            homeTownPlanets.Add(new Planet(new XYPair(1 + x, 2 + y), "Lisnar"));
            homeTownPlanets.Add(new Planet(new XYPair(1 + x, 8 + y), "Amenias"));
            homeTownPlanets.Add(new Planet(new XYPair(9 + x, 2 + y), "Agnesia"));

            return homeTownPlanets;
        }
        // generate location star map


        public List<XYPair> GeneratePlanetLocations(RandomPlanetGenerationScope scope)
        {
            int splitFactor = scope.splitFactor;
            int gridSizeX = scope.size.x;
            int gridSizeY = scope.size.y;
            int radius = scope.radius;
            int maxAmount = scope.maxAmountPerArea;
            List<XYPair> planetLocations = new List<XYPair>();
            for (int x = 0; x < splitFactor; x++)
            {
                for (int y = 0; y < splitFactor; y++)
                {
                    planetLocations.AddRange(GeneratePlanetLocationsInGridSection(x * (gridSizeX + radius),
                        y * (gridSizeY + radius),
                        gridSizeX, gridSizeY, maxAmount, radius));
                }
            }
            return planetLocations;
        }

        private List<XYPair> GeneratePlanetLocationsInGridSection(int startX, int startY, int sizeX,
            int sizeY, int maxAmount, int radius)
        {
            List<XYPair> planetLocations = new List<XYPair>();
            List<XYPair> potentialLocations = new List<XYPair>();


            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    potentialLocations.Add(new XYPair(x + startX, y + startY));
                }
            }


            while ((potentialLocations.Count > 0) && planetLocations.Count < maxAmount)
            {

                int nextIndex = r.Next(potentialLocations.Count - 1);
                planetLocations.Add(potentialLocations[nextIndex]);
                disableRadiusLocations(potentialLocations[nextIndex], potentialLocations, radius);
            }

            return planetLocations;
        }

        private void disableRadiusLocations(XYPair planet, List<XYPair> potentialLocations, int radius)
        {
            int cornerX = planet.getX() - radius;
            int cornerY = planet.getY() - radius;
            for (int x = 0; x < radius * 2; x++)
            {
                for (int y = 0; y < radius * 2; y++)
                {
                    XYPair c1 = new XYPair(x, y);
                    XYPair c2 = new XYPair(radius, radius);
                    if (Calc.WithinDistance(c1, c2, radius))
                    {
                        potentialLocations.Remove(new XYPair(cornerX + x, cornerY + y));
                    }
                }
            }
        }

        public List<XYPair> EmptySpaceForHomeTown(List<XYPair> potentialPlanetLocations, XYPair homeTown)
        {
            potentialPlanetLocations.RemoveAll(l => (l.getX() > homeTown.x && l.getX() < homeTown.x + 12)
                                                && (l.getY() > homeTown.y && l.getY() < homeTown.y + 12));
            return potentialPlanetLocations;
        }

        public List<Planet> PopulateLocation(List<XYPair> potentialPlanetLocations)
        {
            List<Planet> randomPlanets = new List<Planet>();
            int x = 1;
            foreach (XYPair l in potentialPlanetLocations)
            {
                randomPlanets.Add(new Planet(l, GeneratePlanetName(ref r)));
                x++;
            }
            return randomPlanets;
        }



        public static string GeneratePlanetName(ref Random r)
        {

            var name = new StringBuilder();

            var planetLetterIndex = ((char)('a' + r.Next(0, 26))).ToString();
            var planetNumberIndex = r.Next(100, 999).ToString();

            name = name.Append(planetLetterIndex.ToUpper());
            name = name.Append("-");
            name = name.Append(planetNumberIndex);

            return name.ToString();
        }




    }
}
