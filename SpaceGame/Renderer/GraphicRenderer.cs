using System;
using Console = Colorful.Console;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class GraphicRenderer
    {
        public static void PrintBorder(Border border)
        {
            Console.BackgroundColor = Color.FromArgb(12, 12, 12); ;
            string ceilingAndFloor = "";
            string middleSpace = "";
            for (int i = 0; i < border.sizeX - 2; i++)
            {
                ceilingAndFloor += "═";
                middleSpace += " ";
            }
            for (int y = 0; y < border.sizeY; y++)
            {
                Console.SetCursorPosition(border.positionX, border.positionY + y);
                if (y == 0)
                {
                    Console.Write($"╔{ceilingAndFloor}╗", Color.White);
                }
                else if (y == border.sizeY - 1)
                {
                    Console.Write($"╚{ceilingAndFloor}╝", Color.White);

                }
                else
                {
                    Console.Write($"║{middleSpace}║", Color.White);
                }
            }
        }

        public static void PrintImage(XYPair position, Image image)
        {
            int row = position.y;
            foreach (string line in image.bitmap)
            {
                Console.SetCursorPosition(position.x, row);
                char[] nextLine = line.ToCharArray();
                for (int i = 0; i < nextLine.Length; i += 2)
                {
                    string nextPixel = nextLine[i] + "";
                    int nextColorIndex = Convert.ToInt32(nextPixel, 16);
                    setForeground(nextColorIndex, image.colors);
                    nextPixel = nextLine[i + 1] + "";
                    nextColorIndex = Convert.ToInt32(nextPixel, 16);
                    setBackground(nextColorIndex, image.colors);
                    Console.Write("▀");
                }
                row++;
            }
        }

        public static void setForeground(int colorIndex, List<Color> colors)
        {
            if (colorIndex == 0)
            {
                Console.ForegroundColor = Color.FromArgb(12,12,12);
            }
            else if (colorIndex == 15)
            {
                Console.ForegroundColor = Color.White;
            }
            else
            {
                Console.ForegroundColor = colors[colorIndex - 1];
            }
        }

        public static void setBackground(int colorIndex, List<Color> colors)
        {
            if (colorIndex == 0)
            {
                Console.BackgroundColor = Color.FromArgb(12, 12, 12);
            }
            else if (colorIndex == 15)
            {
                Console.BackgroundColor = Color.White;
            }
            else
            {
                Console.BackgroundColor = colors[colorIndex - 1];
            }
        }


    }
}
