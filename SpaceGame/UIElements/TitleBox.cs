using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class TitleBox
    {
        BoundaryBox box = new BoundaryBox(0, 5);
        FreeString content;

        public TitleBox(string title)
        {
            content = new FreeString(2,title);
        }

        public void Print()
        {
            box.Print();
            content.Print();
        }
    }
}
