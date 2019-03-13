using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class RandomAssetGenerator
    {
        Random r = new Random();



        // generate planet



        // generate location star map
        public List<Location> GeneratePlanetLocations(RandomPlanetGenerationScope scope)
        {
            int splitFactor = scope.splitFactor;
            int gridSizeX = scope.size.x;
            int gridSizeY = scope.size.y;
            int radius = scope.radius;
            int maxAmount = scope.maxAmount;
            List <Location> planetLocations = new List<Location>();
            for(int x = 0; x < splitFactor; x++)
            {
                for(int y = 0; y < splitFactor; y++)
                {
                    planetLocations.AddRange(GeneratePlanetLocationsInGridSection(x * (gridSizeX+radius),
                        y * (gridSizeY+ radius),
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

                int nextIndex = r.Next(potentialLocations.Count-1);
                planetLocations.Add(potentialLocations[nextIndex]);
                Console.WriteLine(planetLocations.Last());
                disableRadiusLocations(potentialLocations[nextIndex], potentialLocations, radius);
            }

            return planetLocations;
        }

        private void disableRadiusLocations(Location planet, List<Location> potentialLocations, int radius)
        {
            int cornerX = planet.getX() - radius;
            int cornerY = planet.getY() - radius;
            for (int x = 0; x < radius*2; x++)
            {
                for(int y = 0; y < radius*2; y++)
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

        


    }
}
