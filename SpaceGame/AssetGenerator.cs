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

        public List<Planet> GenerateHomePlanetSystem(List<Planet> planets)
        {
            List<Planet> homeSystem = new List<Planet>();
            homeSystem.Add(new Planet(new Location(5, 5), "Earth"));
            homeSystem.Add(new Planet(new Location(4, 3), "Mars"));
            homeSystem.Add(new Planet(new Location(5, 4), "XCentrolStation"));
            homeSystem.Add(new Planet(new Location(4, 5), "YoRHa"));
            homeSystem.Add(new Planet(new Location(7, 8), "Ernasis"));
            homeSystem.Add(new Planet(new Location(10, 10), "Alpha Centauri 3"));
            homeSystem.Add(new Planet(new Location(0, 2), "Lisnar"));
            homeSystem.Add(new Planet(new Location(1, 8), "Amenias"));
            homeSystem.Add(new Planet(new Location(9, 2), "Agnesia"));
            XYPair homesystem = new XYPair(r.Next(400), r.Next(500));

            return (homeSystem);
        }

        // generate location star map


        public List<Location> GeneratePlanetLocations(RandomPlanetGenerationScope scope)
        {
            int splitFactor = scope.splitFactor;
            int gridSizeX = scope.size.x;
            int gridSizeY = scope.size.y;
            int radius = scope.radius;
            int maxAmount = scope.maxAmountPerArea;
            List<Location> planetLocations = new List<Location>();
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

        private List<Location> GeneratePlanetLocationsInGridSection(int startX, int startY, int sizeX,
            int sizeY, int maxAmount, int radius)
        {
            List<Location> planetLocations = new List<Location>();
            List<Location> potentialLocations = new List<Location>();


            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    potentialLocations.Add(new Location(x + startX, y + startY));
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

        private void disableRadiusLocations(Location planet, List<Location> potentialLocations, int radius)
        {
            int cornerX = planet.getX() - radius;
            int cornerY = planet.getY() - radius;
            for (int x = 0; x < radius * 2; x++)
            {
                for (int y = 0; y < radius * 2; y++)
                {
                    Coordi c1 = new Coordi(x, y);
                    Coordi c2 = new Coordi(radius, radius);
                    if (Calc.withinDistance(c1, c2, radius))
                    {
                        potentialLocations.Remove(new Location(cornerX + x, cornerY + y));
                    }
                }
            }
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
                randomPlanets.Add(new Planet(l, GeneratePlanetName()));
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


        public static string GeneratePlanetName()
        {

            var name = new StringBuilder();
            var random = new Random();

            var planetLetterIndex = ((char)('a' + random.Next(0, 26))).ToString();
            var planetNumberIndex = random.Next(100, 999).ToString();

            name = name.Append(planetLetterIndex.ToUpper());
            name = name.Append("-");
            name = name.Append(planetNumberIndex);

            return name.ToString();
        }




    }
}
