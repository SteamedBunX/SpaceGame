using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    class AugmentingStyledString
    {
        public string text;
        public Color backGroundColor;
        public Color textColor;
        public int layer;
        public int index;
        public AugmentingStyledString(int i, string t, int lyr = 0,
            Color? tColor = null,
            Color? bColor = null)
        {
            text = t;
            if (tColor == null)
            {
                textColor = Color.White;
            }
            else
            {
                textColor = (Color)tColor;
            }
            if (bColor == null)
            {
                backGroundColor = Color.Black;
            }
            else
            {
                backGroundColor = (Color)bColor;
            }
            index = i;
            layer = lyr;
        }
    }
}
