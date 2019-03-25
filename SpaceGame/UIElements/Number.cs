using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Number
    {
        public int i;

        public bool Up()
        {
            if (i >= 9)
            {
                i = 0;
                return true;
            }
            i++;
            return false;
        }

        public bool Down()
        {
            if (i <= 0)
            {
                i = 9;
                return true;
            }
            i--;
            return false;
        }
    }
}
