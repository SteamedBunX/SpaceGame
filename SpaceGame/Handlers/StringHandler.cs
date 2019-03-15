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
        List<LineSkip> lineSkips = new List<LineSkip>();
        int index = 0;
        List<StyledString> stringBitmap = new List<StyledString>();
        List<StyledString> augmentingBitmap = new List<StyledString>();

        public void PrintStringBitmap()
        {
            lineSkips.Sort(CompareLineSkipByLayerIndex);
            SortString();
            StringRenderer.PrintStringBitmap(lineSkips, stringBitmap);
        }

        public void InsertLineSkip(int afterLayer, int numOfLines)
        {
            lineSkips.Add(new LineSkip(afterLayer, numOfLines));
        }

        public void AddStyledString(string text, int lyr = 0,
            TextColor tColor = TextColor.White,
            TextColor bColor = TextColor.Black,
            TextAlignment alignment = TextAlignment.LeftAligned)
        {
            stringBitmap.Add(new StyledString(index, text, lyr, tColor, bColor, alignment));
            index++;
        }

        public void SortString()
        {
            stringBitmap.Sort(CompareStringByLayerIndex);
        }

        public void SortLineSkip()
        {
            lineSkips.Sort(CompareLineSkipByLayerIndex);
        }

        public void ClearStringBitmap()
        {
            index = 0;
            lineSkips.Clear();
            stringBitmap.Clear();
        }

        private static int CompareStringByLayerIndex(StyledString x, StyledString y)
        {
            if (x.layer > y.layer)
            {
                return 1;
            }
            if (x.layer < y.layer)
            {
                return -1;
            }
            if (x.index > y.index)
            {
                return 1;
            }
            if (x.index < y.index)
            {
                return -1;
            }
            return 0;

        }

        private static int CompareLineSkipByLayerIndex(LineSkip x, LineSkip y)
        {
            if(x.afterLayer>y.afterLayer)
            {
                return 1;
            }
            if(x.afterLayer<y.afterLayer)
            {
                return -1;
            }
            return 0;
        }
    }
}
