using System;
using System.Text;

namespace SpaceGame
{
    public class PlanetName
    {
        public string PlanetNameGenerator()
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