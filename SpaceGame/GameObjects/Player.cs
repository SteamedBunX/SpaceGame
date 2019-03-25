using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Player
    {
        ObjectHandler objH;
        public string name;
        public Gender gender;
        public Planet currentPlanet;
        public int money;
        public List<InventoryItem> inventory = new List<InventoryItem>();
        public double wrapFactor = 1.4;
        public int fuel = 320;
        int maxFuel = 320;
        public int ageByMonth = 240;

        public Player(string n, Gender g, ref ObjectHandler objH)
        {
            name = n;
            gender = g;
            this.objH = objH;
        }

        public void Buy(ShopItem item, int amount)
        {
            money -= item.GetPrice() * amount;
            if (inventory.Any(i => i.index == item.GetIndex()))
            {
                var inveItem = inventory.FirstOrDefault(i => i.index == item.GetIndex());
                inveItem.amount += amount;
            }
            else
            {
                inventory.Add(new InventoryItem(item.GetIndex(), amount, item.GetName()));
            }
        }

        public void Sale(ShopItem item, int amount)
        {
            money += item.GetPrice() * amount;
            var inveItem = inventory.FirstOrDefault(i => i.index == item.GetIndex());
            inveItem.amount -= amount;
            if (inveItem.amount == 0)
            {
                inventory.Remove(inveItem);
            }
        }

        public string GetName()
        {
            return name;
        }

        public void setPlanet(Planet p)
        {
            currentPlanet = p;
        }

        public int GetAge()
        {
            return ageByMonth / 12;
        }

        public Planet GetCurrentPlanet()
        {
            return currentPlanet;
        }

        public string GetSpeed()
        {
            double velocity = Math.Pow(wrapFactor, (10.0 / 3.0)) + Math.Pow((10 - wrapFactor), (-11.0 / 3.0));
            return String.Format("{0:0.00} Lightyear/Year", velocity);
        }

        public double GetTravelSpeed()
        {
            return Math.Pow(wrapFactor, (10.0 / 3.0)) + Math.Pow((10 - wrapFactor), (-11.0 / 3.0));
        }

        public string GetFuelLevel()
        {
            double fuelLevel = ((double)fuel / maxFuel);
            return string.Format("{0:P2}", fuelLevel);
        }

        public List<Planet> GetPlanetWithinReach()
        {
            List<Planet> planets = new List<Planet>();
            foreach (Planet p in objH.planets)
            {
                if (p.location - currentPlanet.location < 9)
                {
                    if (p.location != currentPlanet.location)
                    {
                        planets.Add(p);
                    }
                }
            }
            return planets;
        }

        public void Travel(Planet planet)
        {
            double distance = currentPlanet.location - planet.location;
            int fuelCost = (int)(distance * 10);
            ageByMonth += (int)(distance / GetTravelSpeed() * 12);
            fuel -= fuelCost;
            setPlanet(planet);
        }

        public void refuel()
        {
            int amount = maxFuel - fuel;
            fuel = maxFuel;
            money -= amount * currentPlanet.fuelPrice;
        }
    }
}
