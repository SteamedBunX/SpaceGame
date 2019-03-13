using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Location
    {
        int x, y;
        public Location(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int getX() => x;

        public int getY() => y;

        public void updateLocation(Location l)
        {
            x = l.getX();
            y = l.getY();
        }

        public override string ToString()
        {
            return $"Cordinate: ({x}, {y})";
        }

        public override int GetHashCode()
        {
            return y ^ x;
        }

        public override bool Equals(object value)
        {
            if(value == null)
            {
                return false;
            }
            if(value.GetType() == this.GetType())
            {
                Location l = value as Location;
                    return (x == l.getX() && y == l.getY());

            }
            return false;
        }
    }

    
}
