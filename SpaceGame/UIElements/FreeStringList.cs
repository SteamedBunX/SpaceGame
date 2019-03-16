using System;
using System.Collections.Generic;
using Console = Colorful.Console;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class FreeStringList
    {
        List<FreeString> freeStringBitmap = new List<FreeString>();
        List<FreeStringBundle> freeStringBundle = new List<FreeStringBundle>();

        public void PrintFreeStrings()
        {
            foreach(FreeString s in freeStringBitmap)
            {
                XYPair sP = s.GetStartingPoint();
                Console.SetCursorPosition(sP.x, sP.y);
                Console.ForegroundColor = s.textColor;
                Console.BackgroundColor = s.backgroundColor;
                Console.Write(s.text);
            }
            Console.ResetColor();
        }

        public void AddFreeString(int row, string t,
           TextColor tColor = TextColor.White, TextColor bColor = TextColor.Black,
           Alignment alignment = Alignment.Centered)
        {
            freeStringBitmap.Add(new FreeString(row, t, tColor, bColor, alignment));
        }

        public void AddFreeString(XYPair position, string t,
            TextColor tColor = TextColor.White, TextColor bColor = TextColor.Black)
        {
            freeStringBitmap.Add(new FreeString(position, t, tColor, bColor));
        }

        public void ClearFreeString()
        {
            freeStringBitmap.Clear();
        }
    }
}
