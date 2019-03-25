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

        public void Print(XYPair position, string imageName)
        {
            int index = images.FindIndex(f => f.name == imageName);
            if (index >= 0)
            {
                Image imageSelected = images[index];
                GraphicRenderer.PrintImage(position, imageSelected);
            }
            else
            {
                StringRenderer.PrintFreeString(new FreeString(new XYPair(position.x, position.y),
                    $"Image: {imageName} not find", TextColor.Red, alignment: Alignment.LeftAligned));
            }
        }
    }
}
