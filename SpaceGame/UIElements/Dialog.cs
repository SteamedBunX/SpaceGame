using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.UIElements
{
    class Dialog
    {
        public int width, height, x, y;
        public BoxStyle style = BoxStyle.FullSize;
        public BoxAlignment alignment = BoxAlignment.Centered;
        public Dialog(int row, int _height)
        {
            width = Console.WindowWidth;
            height = _height;
        }

        public Dialog(Coordi position, XYPair size)
        {
            alignment = BoxAlignment.Free;
            x = position.x;
            y = position.y;
            width = size.x;
            height = size.y;
        }

        public Dialog(int row, XYPair size)
        {
            alignment = BoxAlignment.Free;
            x = row;
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

        }


    }
}
