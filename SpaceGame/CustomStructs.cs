
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

}
