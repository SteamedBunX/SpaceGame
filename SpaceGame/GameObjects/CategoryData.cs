using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class CategoryData
    {
        public int index;
        string name;
        double supplyInflation, demandInflation;
        List<ShopItemData> itemDatas = new List<ShopItemData>();
        public CategoryData(int index, string name, double supplyInflation, double demandInflation)
        {
            this.index = index;
            this.name = name;
            this.supplyInflation = supplyInflation;
            this.demandInflation = demandInflation;
        }

        public double GetSupplyInflation()
        {
            return supplyInflation;
        }

        public double GetDemandInflation()
        {
            return demandInflation;
        }

        public void AddItem(int index, string name, int basePrice, double maxInflation)
        {
            ShopItemData item = new ShopItemData(index, name, basePrice, maxInflation);
            itemDatas.Add(item);
        }

        public List<ShopItem> GetItems(ref Random r)
        {
            List<ShopItem> items = new List<ShopItem>();
            foreach (ShopItemData data in itemDatas)
            {
                items.Add(data.GetShopItem(ref r));
            }


            return items;
        }

        public string GetName()
        {
            return name;
        }
    }
}
