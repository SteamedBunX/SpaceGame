﻿using System;
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
        public int splitFactor, radius, maxAmountPerArea;

        public RandomPlanetGenerationScope(XYPair s, int sF, int r, int maxPerArea)
        {
            size = s;
            splitFactor = sF;
            radius = r;
            maxAmountPerArea = maxPerArea;
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

        public Border(XYPair size, Coordi position)
        {
            sizeX = size.x;
            sizeY = size.y;
            positionX = position.x;
            positionY = position.y;
        }
    }


}
