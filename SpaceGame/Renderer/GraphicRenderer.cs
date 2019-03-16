using System;
using Console = Colorful.Console;
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
            string ceilingAndFloor = "";
            string middleSpace = "";
            for (int i = 0; i < border.sizeX; i++)
            {
                ceilingAndFloor += "═";
                middleSpace += " ";
            }
            Console.SetCursorPosition(border.positionX, border.positionY);
            for (int y = 0; y < border.sizeY; y++)
            {
                Console.SetCursorPosition(border.positionX, border.positionY + y);
                if (y == 0)
                {
                    Console.Write($"╔{ceilingAndFloor}╗");
                }
                else if (y == border.sizeY - 1)
                {
                    Console.Write($"╚{ceilingAndFloor}╝");

                }
                else
                {
                    Console.Write($"║{middleSpace}║");
                }
            }
        }
    }
}
