using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Border
    {
        public int sizeX,sizeY,positionX,positionY;
        
        public Border(XYPair size, Coordi position)
        {
            sizeX = size.x;
            sizeY = size.y;
            positionX = position.x;
            positionY = position.y;
        }
    }
}
