using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Game
    {

        ObjectHandler obsH = new ObjectHandler();
        PagesHundler pgsH;

        public void Ini()
        {
            obsH.Ini();
            pgsH = new PagesHundler(ref obsH);
        }

        public void Run()
        {
            Pages pageSwitch = Pages.MainMenu;
            //TestEntryPoint
            //AssetGenerator a = new AssetGenerator();
            //pgsH.objH = a.GetDefaultObjectHandler();
            //pageSwitch = Pages.Ship;
            //pageSwitch = Pages.Shop;
            //pageSwitch = Pages.Buy;
            //pageSwitch = Pages.Inventory;
            //pageSwitch = Pages.Travel;
            //TestingEnviroment Entrypoint
            //pageSwitch = Pages.TestPage;
            while (pageSwitch != Pages.Exit)
            {
                switch (pageSwitch)
                {
                    case Pages.TestPage:
                        pageSwitch = pgsH.TestPage();
                        break;
                    case Pages.MainMenu:
                        pageSwitch = pgsH.MainMenu();
                        break;
                    case Pages.NewCharacter:
                        pageSwitch = pgsH.CreateNewData();
                        break;
                    case Pages.Ship:
                        pageSwitch = pgsH.Ship();
                        break;
                    case Pages.Shop:
                        pageSwitch = pgsH.Shop();
                        break;
                    case Pages.Buy:
                        pageSwitch = pgsH.Buy();
                        break;
                    case Pages.Sale:
                        pageSwitch = pgsH.Sale();
                        break;
                    case Pages.Inventory:
                        pageSwitch = pgsH.Inventory();
                        break;
                    case Pages.Travel:
                        pageSwitch = pgsH.Travel();
                        break;
                    default:
                        pageSwitch = pgsH.MainMenu();
                        break;
                }
            }





            // Test codes
            //while (!exit)
            //{
            //    Console.WriteLine($"You are current at the location: {obs.player.GetCurrentPlanet().GetLocation()}");
            //    List<Planet> accessablePlanet = new List<Planet>();
            //    int accessableR = 18;
            //    Console.WriteLine("Current accessable planets are as follow: ");
            //    int count = 0;
            //    foreach (Planet p in obs.planets)
            //    {
            //        Location currentPlyrLocation = obs.player.GetCurrentPlanet().GetLocation();
            //        Coordi pCord = new Coordi(p.GetLocation().getX(), p.GetLocation().getY());
            //        Coordi playerCord = new Coordi(currentPlyrLocation.getX(),currentPlyrLocation.getY());
            //        if (Calc.withinDistance(pCord, playerCord, accessableR) 
            //            && p.GetLocation() != obs.player.GetCurrentPlanet().GetLocation())
            //        {
            //            count++;
            //            accessablePlanet.Add(p);
            //            Console.WriteLine($"{count}. {p.GetLocation()}");
            //        }
            //    }
            //    Console.Write("Please enter the index of the planet you would like to move to");
            //    int index = int.Parse(Console.ReadLine());
            //    obs.player.setPlanet(accessablePlanet[index - 1]);
            //}
        }


    }
}
