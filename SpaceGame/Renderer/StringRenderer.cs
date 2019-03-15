using System;
using Console = Colorful.Console;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class StringRenderer
    {
        public static void printAugmentingString(XYPair cursorPosition, Color bColor, Color fColor, string content)
        {
            Console.SetCursorPosition(cursorPosition.y, cursorPosition.x);
            Console.BackgroundColor = bColor;
            Console.ForegroundColor = fColor;
            Console.Write(content);
        }
    }
}
