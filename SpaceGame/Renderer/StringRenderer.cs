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
        public static void PrintFreeStrings(List<FreeString> freeStrings)
        {
            foreach(FreeString s in freeStrings)
            {
                PrintFreeString(s);
            }
        }

        public static void PrintFreeString(FreeString fs)
        {
            Console.SetCursorPosition(fs.GetStartingPoint().x, fs.GetStartingPoint().y);
            Console.BackgroundColor = fs.backgroundColor;
            Console.ForegroundColor = fs.textColor;
            Console.Write(fs.text);
        }

        public static void PrintFreeStringBundle(FreeStringBundle fSBundle)
        {
            foreach(FreeString fs in fSBundle.content)
            {
                PrintFreeString(fs);
            }
        }
    }
}
