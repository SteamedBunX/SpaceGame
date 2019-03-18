using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class ImageHandler
    {
        public List<Image> images = new List<Image>();

        public void LoadImages(string imageFolderPath)
        {
            foreach (string f in Directory.GetFiles(imageFolderPath))
            {
                images.Add(new Image(f));
            }
        }

        public void Print(Coordi position, string imageName)
        {
            Image imageSelected = images.FirstOrDefault(l => (l.name == imageName));
            GraphicRenderer.PrintImage(position,imageSelected);
        }
    }
}
