using System;
namespace SpaceGame
{
    public struct XYPair
    {
        public int x, y;
        public XYPair(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX() => x;
        public int getY() => y;

        public static double operator -(XYPair p1, XYPair p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2));
        }

        public static bool operator ==(XYPair p1, XYPair p2)
        {
            return (p1.x == p2.x && p1.y == p2.y);
        }

        public static bool operator !=(XYPair p1, XYPair p2)
        {
            return !(p1.x == p2.x && p1.y == p2.y);
        }
    }

    public struct RandomPlanetGenerationScope
    {
        public XYPair size;
        public int splitFactor, radius, maxAmountPerArea;

        public RandomPlanetGenerationScope(XYPair s, int sF, int r, int maxPerArea)
        {
            size = s;
            splitFactor = sF;
            radius = r;
            maxAmountPerArea = maxPerArea;
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

    public struct DataString
    {
        public string text;
        public int index;
        public DataString(int _index, string input)
        {
            index = _index;
            text = input;
        }
    }

    public struct Border
    {
        public int sizeX, sizeY, positionX, positionY;

        public Border(XYPair size, XYPair position)
        {
            sizeX = size.x;
            sizeY = size.y;
            positionX = position.x;
            positionY = position.y;
        }
    }

    public struct Item
    {
        int index;
        string name;

        public Item(int index, string name)
        {
            this.index = index;
            this.name = name;
        }

        public int GetIndex()
        {
            return index;
        }

        public string GetName()
        {
            return name;
        }
    }

    public struct ShopItem
    {
        Item item;
        int price;
        public ShopItem(Item item, int price)
        {
            this.item = item;
            this.price = price;
        }

        public void SetPrice(double inflation1 = 1.0, double inflation2 = 1.0, double inflation3 = 1.0)
        {
            price = (int)(price * inflation1 * inflation2 * inflation3);
        }

        public int GetIndex()
        {
            return item.GetIndex();
        }

        public String GetName()
        {
            return item.GetName();
        }

        public int GetPrice()
        {
            return price;
        }
    }

    public struct ShopItemData
    {
        Item item;
        int basePrice;
        double maxInflation;

        public ShopItemData(int index, string name, int basePrice, double maxInflation)
        {
            item = new Item(index, name);
            this.basePrice = basePrice;
            this.maxInflation = maxInflation;
        }

        public ShopItem GetShopItem(ref Random r)
        {
            int price = (int)((r.NextDouble() * (maxInflation - 1) + 1) * basePrice);
            return new ShopItem(item, price);
        }
    }

    public struct InventoryItem
    {
        public int index;
        public int amount;
        public string name;

        public InventoryItem(int index, int amount, string name)
        {
            this.index = index;
            this.amount = amount;
            this.name = name;
        }

        public void Bought(int amount)
        {
            this.amount += amount;
        }

        public void Sold(int amount)
        {
            this.amount -= amount;
        }
    }



}
