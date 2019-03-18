using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Image
    {
        public string name;
        public List<Color> colors = new List<Color>();
        public List<string> bitmap = new List<string>();

        public Image(string path)
        {
            string[] pathParts = path.Split('\\');
            name = pathParts.Last();
            name = name.Split('.')[0];
            ProcessImage(path);
            //C:\MSSA\Homework SLN\SpaceGame\SpaceGame\Images\Logo.ci

        }

        public void ProcessImage(string path)
        {
            StreamReader img = new StreamReader(path);
            bool colorSet = false;
            string nextColor = img.ReadLine();
            List<string> colorsInHax = new List<string>();
            do
            {
                if (nextColor == "")
                {
                    colorSet = true;
                }
                else
                {
                    colorsInHax.Add(nextColor);
                }
                nextColor = img.ReadLine();
            } while (!colorSet);
            FillColor(colorsInHax);
            while (!img.EndOfStream)
            {
                bitmap.Add(img.ReadLine());
            }
        }

        public void FillColor(List<string> hexColors)
        {
            foreach (string hc in hexColors)
            {
                ColorConverter converter = new ColorConverter();
                colors.Add((Color)converter.ConvertFromString(hc));
            }
        }
    }
}
