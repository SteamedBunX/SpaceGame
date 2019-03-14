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
        public Coordi(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public static double operator -(Coordi c1, Coordi c2)
        {
            return Math.Sqrt(Math.Pow((c1.x - c2.x), 2) + Math.Pow((c1.y - c2.y), 2));
        }
    }

    public struct LineSkip
    {
        public int afterLayer, numOfLines;

        public LineSkip(int _afterLayer, int _numOfLines)
        {
            afterLayer = _afterLayer;
            numOfLines = _numOfLines;
        }
    }

    public struct ShopItem
    {
        public int index, amount, price;
        public ShopItem(int _index, int _amount, int _price)
        {
            index = _index;
            amount = _amount;
            price = _price;
        }
    }

    public struct MenuItem
    {
        string itemName;
        MenuPart part;
        TextAlignment alignment;
        public MenuItem(string _itemName, MenuPart menuPart, TextAlignment _alignment)
        {
            itemName = _itemName;
            part = menuPart;
            alignment = _alignment;
        }
    }

}
