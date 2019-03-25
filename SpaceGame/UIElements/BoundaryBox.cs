using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class BoundaryBox
    {
        public int width, height, x, y;
        public BoxStyle style = BoxStyle.FullSize;
        public Alignment alignment = Alignment.Centered;
        public int spacing;
        public BoundaryBox(int row, int _height)
        {
            y = row;
            width = 120;
            height = _height;
            x = Console.LargestWindowWidth / 2 - 60;
        }

        public BoundaryBox(XYPair position, XYPair size)
        {
            alignment = Alignment.Free;
            x = position.x;
            y = position.y;
            width = size.x;
            height = size.y;
        }

        public BoundaryBox(int row, XYPair size, Alignment boxAlignment = Alignment.Centered)
        {
            alignment = boxAlignment;
            y = row;
            width = size.x;
            height = size.y;
        }

        public BoundaryBox(int row, int spacing, XYPair size, Alignment boxAlignment = Alignment.RightAligned)
        {
            alignment = boxAlignment;
            y = row;
            width = size.x;
            height = size.y;
            this.spacing = spacing;
        }

        public void SetSize(XYPair size)
        {
            width = size.x;
            height = size.y;
        }

        public void Print()
        {
            int alignX = 0;
            int temp;
            switch (alignment)
            {
                case Alignment.LeftAligned:
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new XYPair(spacing, y)));
                    break;
                case Alignment.Centered:
                    temp = (Console.WindowWidth - width) / 2 - 1;
                    alignX = temp > 0? temp : 0;
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new XYPair(alignX, y)));
                    break;
                case Alignment.RightAligned:
                    temp = (Console.WindowWidth - width) - spacing-1;
                    alignX = temp > 0 ? temp : 0;
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new XYPair(alignX, y)));
                    break;
                case Alignment.Free:
                    GraphicRenderer.PrintBorder(new Border(new XYPair(width, height), new XYPair(x, y)));
                    break;
                default:
                    break;
            }
            Console.CursorVisible = false;

        }


    }
}
