using System;
namespace SpaceGame
{
    public struct XYPair
    {
        public int x, y;
        public XYPair(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    public struct RandomPlanetGenerationScope
    {
        public XYPair size;
        public int splitFactor, radius, maxAmount;

        public RandomPlanetGenerationScope(XYPair s, int sF, int r, int mA)
        {
            size = s;
            splitFactor = sF;
            radius = r;
            maxAmount = mA;
        }
    }

    public struct Coordi
    {
        public int x, y;
        public Coordi(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
        public static double operator -(Coordi c1, Coordi c2)
        {
            return Math.Sqrt(Math.Pow((c1.x - c2.x), 2) + Math.Pow((c1.y - c2.y), 2));
        }
    }

}
