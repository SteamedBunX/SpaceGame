using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    public class FreeString
    {
        public string text;
        public Color backgroundColor;
        public Color textColor;
        public int x, y;
        public Alignment textAlignment = Alignment.Free;
        public FreeString(XYPair position, string t,
            TextColor tColor = TextColor.White, TextColor bColor = TextColor.Black,
            Alignment alignment = Alignment.Free)
        {

            SetTextColor(tColor);
            SetBackgroundColor(bColor);
            textAlignment = alignment;
            text = t;
            x = position.x;
            y = position.y;
        }

        public FreeString(XYPair position, string t,
    Color tColor, Color bColor,
    Alignment alignment = Alignment.Free)
        {

            textColor = tColor;
            backgroundColor = bColor;
            textAlignment = alignment;
            text = t;
            x = position.x;
            y = position.y;
        }

        public FreeString(int row, string t,
           TextColor tColor = TextColor.White, TextColor bColor = TextColor.Black,
           Alignment alignment = Alignment.Centered)
        {

            SetTextColor(tColor);
            SetBackgroundColor(bColor);
            textAlignment = alignment;
            int temp;
            switch (alignment)
            {
                case Alignment.LeftAligned:
                    x = 0;
                    break;
                case Alignment.Centered:
                    temp = (Console.WindowWidth - t.Length) / 2 - 1;
                    x = temp > 0 ? temp : 0;
                    break;
                case Alignment.RightAligned:
                    temp = Console.WindowWidth - t.Length;
                    x = temp > 0 ? temp : 0;
                    break;
                default:
                    break;
            }
            text = t;
            y = row;
        }

        public XYPair GetStartingPoint()
        {
            switch (textAlignment)
            {
                case Alignment.LeftAligned:
                    return new XYPair(0, y);
                case Alignment.Centered:
                    return new XYPair((Console.WindowWidth - text.Length) / 2, y);
                case Alignment.RightAligned:
                    return new XYPair(Console.WindowWidth - text.Length, y);
            }
            return new XYPair(x, y);
        }

        public void SetTextColor(TextColor tColor)
        {
            switch (tColor)
            {
                case TextColor.Black:
                    textColor = Color.FromArgb(12,12,12);
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
        }

        public void SetBackgroundColor(TextColor bColor)
        {
            switch (bColor)
            {
                case TextColor.Black:
                    backgroundColor = Color.FromArgb(12,12,12);
                    break;
                case TextColor.White:
                    backgroundColor = Color.White;
                    break;
                case TextColor.Red:
                    backgroundColor = Color.Red;
                    break;
                case TextColor.Yellow:
                    backgroundColor = Color.Yellow;
                    break;
                default:
                    break;
            }
        }

        public void Print()
        {
            StringRenderer.PrintFreeString(this);
        }
    }
}
