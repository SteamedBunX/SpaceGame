using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class DialogBox
    {
        public int width, height, x, y;
        public BoxStyle style = BoxStyle.FullSize;
        public Alignment alignment = Alignment.Centered;
        public DialogBox(int row, int _height)
        {
            y = row;
            width = Console.WindowWidth;
            height = _height;
        }

        public DialogBox(Coordi position, XYPair size)
        {
            alignment = Alignment.Free;
            x = position.x;
            y = position.y;
            width = size.x;
            height = size.y;
        }

        public DialogBox(int row, XYPair size, Alignment boxAlignment = Alignment.Centered)
        {
            alignment = boxAlignment;
            y = row;
            width = size.x;
            height = size.y;
        }

        public void SetSize(XYPair size)
        {
            width = size.x;
            height = size.y;
        }

        public void Print()
        {
            int alignX = 0;
            switch (alignment)
            {
                case Alignment.LeftAligned:
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new Coordi(0, y)));
                    break;
                case Alignment.Centered:
                    alignX = (Console.WindowWidth - width) / 2 - 1;
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new Coordi(alignX, y)));
                    break;
                case Alignment.RightAligned:
                    alignX = Console.WindowWidth - width - 1;
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new Coordi(alignX, y)));
                    break;
                case Alignment.Free:
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new Coordi(x, y)));
                    break;
                default:
                    break;
            }

        }


    }
}
