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
        public static void PrintAugmentingString(XYPair cursorPosition, Color bColor, Color fColor, string content)
        {
            Console.SetCursorPosition(cursorPosition.y, cursorPosition.x);
            Console.BackgroundColor = bColor;
            Console.ForegroundColor = fColor;
            Console.Write(content);
        }

        public static void PrintStringBitmap(List<LineSkip> lineSkips, List<StyledString> stringBitmap)
        {
            List<LineSkip> lineSkipsTemp = new List<LineSkip>(lineSkips);
            foreach (StyledString s in stringBitmap)
            {
                if (lineSkipsTemp.Count > 0)
                {
                    if (s.layer > lineSkipsTemp[0].afterLayer)
                    {
                        for (int i = 0; i < lineSkipsTemp[0].numOfLines; i++)
                        {
                            Console.WriteLine();
                        }
                        lineSkipsTemp.RemoveAt(0);
                    }
                }

                Console.BackgroundColor = s.backGroundColor;
                Console.ForegroundColor = s.textColor;
                PrintLine(s);
                Console.WriteLine();
            }
        }

        public static void PrintLine(StyledString s)
        {
            Console.BackgroundColor = s.backGroundColor;
            Console.ForegroundColor = s.textColor;
            if (s.textAlignment == TextAlignment.LeftAligned)
            {
                Console.Write(s.text);
            }else if (s.textAlignment == TextAlignment.RightAligned)
            {
                Console.SetCursorPosition(Console.WindowWidth - s.text.Length, Console.CursorTop);
                Console.Write(s.text);
            }else
            {
                Console.SetCursorPosition((Console.WindowWidth - s.text.Length)/2, Console.CursorTop);
                Console.Write(s.text);
            }
        }
    }
}
