using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class StringHandler
    {
        List<StyledString> stringBitmap = new List<StyledString>();
        public void print()
        {
            sortString();
            foreach(StyledString s in stringBitmap)
            {
                Console.BackgroundColor = s.backGroundColor;
                Console.ForegroundColor = s.textColor;
                Console.Write(s.text);
            }
            stringBitmap.Clear();
        }

        public void AddStyledString(int i, string t, int lyr = 0, 
            ConsoleColor tColor = ConsoleColor.White,
            ConsoleColor bColor = ConsoleColor.Black)
        {
            stringBitmap.Add(new StyledString(i, t, lyr, tColor, bColor));
        }

        public void sortString()
        {
            stringBitmap.Sort(CompareStringByLayerIndex);
        }

        private static int CompareStringByLayerIndex(StyledString x, StyledString y)
        {
            if(x.layer > y.layer)
            {
                return 1;
            }
            if(x.layer < y.layer)
            {
                return -1;
            }
            if(x.index > y.index)
            {
                return 1;
            }
            if(x.index < y.index)
            {
                return -1;
            }
            return 0;
            
        }
    }
}
