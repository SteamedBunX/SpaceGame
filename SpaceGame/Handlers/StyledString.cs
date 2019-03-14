using System;
using Console = Colorful.Console;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class StyledString
    {
        public string text;
        public Color backGroundColor;
        public Color textColor;
        public int layer;
        public int index;
        public TextAlignment textAlignment;
        public StyledString(int i, string t, int lyr = 0, 
            TextColor tColor = TextColor.White, 
            TextColor bColor = TextColor.Black,
            TextAlignment alignment = TextAlignment.LeftAligned)
        {
            text = t;
            switch (tColor)
            {
                case TextColor.Black:
                    textColor = Color.Black;
                    break;
                case TextColor.White:
                    textColor = Color.White;
                    break;
                case TextColor.Red:
                    textColor = Color.Red;
                    break;
                case TextColor.Yellow:
                    textColor = Color.Yellow;
                    break;
                default:
                    break;
            }
            switch (bColor)
            {
                case TextColor.Black:
                    backGroundColor = Color.Black;
                    break;
                case TextColor.White:
                    backGroundColor = Color.White;
                    break;
                case TextColor.Red:
                    backGroundColor = Color.Red;
                    break;
                case TextColor.Yellow:
                    backGroundColor = Color.Yellow;
                    break;
                default:
                    break;
            }
            index = i;
            layer = lyr;
            textAlignment = alignment;
        }
    }
}
