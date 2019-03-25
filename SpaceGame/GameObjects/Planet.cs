using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Planet
    {
        public string name;
        public XYPair location;
        public bool loaded;
        public string supplies, demands;
        public List<int> supplyIndexs, demandIndexs;
        public List<ShopItem> supplyShop, demandShop;
        public int fuelPrice = 5;
        //        bool generated;
        public Planet(XYPair location, string name)
        {
            this.name = name;
            this.location = location;
        }

        public void GenerateMarket(ref Random r, List<CategoryData> datas)
        {
            supplyShop = new List<ShopItem>();
            demandShop = new List<ShopItem>();
            supplyIndexs = new List<int>();
            demandIndexs = new List<int>();
            supplies = "";
            demands = "";
            List<int> includedIndex = new List<int>();
            int nextIndex;
            for (int i = r.Next(1, 3); i > 0; i--)
            {
                do
                {
                    nextIndex = r.Next(datas.Count - 1);
                } while (includedIndex.Contains(nextIndex));
                supplyIndexs.Add(nextIndex);
                includedIndex.Add(nextIndex);
                supplies += $" {datas[nextIndex].GetName()}";
                List<ShopItem> currentCategory = datas[nextIndex].GetItems(ref r);
                foreach (ShopItem item in currentCategory)
                {
                    item.SetPrice(datas[nextIndex].GetSupplyInflation());
                }
                supplyShop.AddRange(currentCategory);
            }
            for (int i = r.Next(1, 3); i > 0; i--)
            {
                do
                {
                    nextIndex = r.Next(datas.Count - 1);
                } while (includedIndex.Contains(nextIndex));
                includedIndex.Add(nextIndex);
                demandIndexs.Add(nextIndex);
                demands += $" {datas[nextIndex].GetName()}";
                List<ShopItem> currentCategory = datas[nextIndex].GetItems(ref r);
                foreach (ShopItem item in currentCategory)
                {
                    item.SetPrice(datas[nextIndex].GetDemandInflation());
                }
                demandShop.AddRange(currentCategory);
            }
        }

        public void RefreshFuelPrice(ref Random r)
        {
            fuelPrice = r.Next(3, 20);
        }

        public void RefreshMarket(ref Random r, List<CategoryData> datas)
        {
            supplyShop.Clear();
            demandShop.Clear();
            foreach (int index in supplyIndexs)
            {
                List<ShopItem> currentCategory = datas[index].GetItems(ref r);
                foreach (ShopItem item in currentCategory)
                {
                    item.SetPrice(datas[index].GetSupplyInflation());
                }
                supplyShop.AddRange(currentCategory);
            }
            foreach (int index in demandIndexs)
            {
                List<ShopItem> currentCategory = datas[index].GetItems(ref r);
                foreach (ShopItem item in currentCategory)
                {
                    item.SetPrice(datas[index].GetDemandInflation());
                }
                demandShop.AddRange(currentCategory);
            }
        }

        public string GetName()
        {
            return name;
        }

        public XYPair GetLocation()
        {
            return location;
        }
    }
}
