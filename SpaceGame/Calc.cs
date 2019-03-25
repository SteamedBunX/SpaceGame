using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGame;

namespace SpaceGame
{
    class Calc
    {
        public static bool WithinDistance(XYPair c1, XYPair c2, int r)
        {
            return c1 - c2 < r;
        }

        public static string GetShopDisplay(ShopItem item)
        {
            string itemName = item.GetName();
            string itemPrice = item.GetPrice().ToString();
            int totalChar = itemName.Count() + itemPrice.Count();
            string spaces = "";
            for (int i = 0; i < 60 - totalChar; i++)
            {
                spaces += " ";
            }
            return itemName + spaces + itemPrice;
        }

        public static string GetInventoryDisplay(InventoryItem item)
        {
            string itemName = item.name;
            string itemAmount = item.amount.ToString();
            int totalChar = itemName.Count() + itemAmount.Count();
            string spaces = "";
            for (int i = 0; i < 60 - totalChar; i++)
            {
                spaces += " ";
            }
            return itemName + spaces + itemAmount;
        }
    }
}
