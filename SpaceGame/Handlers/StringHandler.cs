using System;
using System.Collections.Generic;
using Console = Colorful.Console;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class StringHandler
    {
        int index = 0;
        List<StyledString> stringBitmap = new List<StyledString>();
        List<StyledString> augmentingBitmap = new List<StyledString>();

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

        public void AddStyledString(string text, int lyr = 0,
            TextColor tColor = TextColor.White,
            TextColor bColor = TextColor.Black,
            TextAlignment alignment = TextAlignment.LeftAligned)
        {
            stringBitmap.Add(new StyledString(index, text, lyr, tColor, bColor, alignment));
            index++;
        }

        public void sortString()
        {
            stringBitmap.Sort(CompareStringByLayerIndex);
        }

        public void ClearStringBitmap()
        {
            stringBitmap.Clear();
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
