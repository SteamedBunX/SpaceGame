using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class StyledString
    {
        public string text;
        public ConsoleColor backGroundColor;
        public ConsoleColor textColor;
        public int layer;
        public int index;
        public StyledString(int i, string t, int lyr = 0, 
            ConsoleColor tColor = ConsoleColor.White, 
            ConsoleColor bColor = ConsoleColor.Black)
        {
            text = t;
            textColor = tColor;
            backGroundColor = bColor;
            index = i;
            layer = lyr;
        }
    }
}
