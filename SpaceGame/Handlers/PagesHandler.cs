using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class PagesHundler
    {
        public ObjectHandler objH;
        int edge = Console.LargestWindowWidth / 2 - 60;

        public PagesHundler(ref ObjectHandler _objH)
        {
            objH = _objH;
        }

        public Pages MainMenu()
        {
            Console.Clear();
            Menu menu = new Menu(36);
            menu.AddItem(new MenuItem("New Game", Alignment.Centered));
            menu.AddItem(new MenuItem("Load Data", Alignment.Centered));
            menu.AddItem(new MenuItem("Credit", Alignment.Centered));
            menu.AddItem(new MenuItem("Exit", Alignment.Centered));
            menu.SetEntryPoint(1);
            XYPair bgSize = new XYPair(20, 6);
            BoundaryBox box = new BoundaryBox(35, bgSize);

            box.Print();
            objH.PrintImage(new XYPair(35, 5), "Logo");

            int i = menu.EnterMenuLoop();
            switch (i)
            {
                case 0:
                    return Pages.NewCharacter;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    return Pages.Exit;
                default:
                    break;
            }

            return Pages.MainMenu;
        }

        public Pages CreateNewData()
        {

            Console.Clear();
            FreeStringBundle fSB = new FreeStringBundle(21);
            fSB.AddFreeString("Hello Advanturer");
            fSB.AddFreeString("What is your name?");
            BoundaryBox box = new BoundaryBox(20, new XYPair(24, 7));
            box.Print();
            fSB.Print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 2);
            string playerName = Console.ReadLine();


            Console.Clear();
            fSB.ClearContent();

            fSB.AddFreeString($"Ok, {playerName}");
            fSB.AddFreeString("What is your gender?");
            XYPair bgSize = new XYPair(24, 7);
            Menu menu = new Menu(24);
            menu.AddItem(new MenuItem("Male", Alignment.Centered));
            menu.AddItem(new MenuItem("Female", Alignment.Centered));
            menu.SetEntryPoint(0);
            box.Print();
            fSB.Print();
            Gender playerGender = menu.EnterMenuLoop() == 0 ? Gender.Male : Gender.Female;
            box.Print();
            fSB.Print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string gender = playerGender.ToString();
            objH.player = new Player(playerName, playerGender, ref objH);
            objH.player.money = 500;



            Console.Clear();
            bgSize = new XYPair(35, 5);
            box.SetSize(bgSize);
            fSB.ClearContent();
            fSB.AddFreeString($"Your Name is {playerName}");
            fSB.AddFreeString($"Your Gender is {gender}");
            fSB.AddFreeString($"Press Enter to find your home");
            box.Print();
            fSB.Print();
            Console.ReadLine();

            objH.GenerateNewData();




            return Pages.Ship;
        }

        public Pages Ship()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("SHIP");
            List<BoundaryBox> boxs = new List<BoundaryBox>();


            boxs.Add(new BoundaryBox(25, edge, new XYPair(69, 20), Alignment.RightAligned));
            boxs.Add(new BoundaryBox(25, edge, new XYPair(50, 20), Alignment.LeftAligned));
            boxs.Add(new BoundaryBox(5, edge, new XYPair(60, 20), Alignment.RightAligned));
            titleBox.Print();


            List<FreeStringBundle> fSBs = new List<FreeStringBundle>();
            fSBs.Add(new FreeStringBundle(9, edge + 70, 200));
            string supplies = objH.player.currentPlanet.supplies;

            string demands = objH.player.currentPlanet.demands;
            fSBs[0].AddFreeString($"Current Planet: {objH.player.currentPlanet.name}", alignment: Alignment.LeftAligned);
            fSBs[0].AddFreeString($"Supply(s):{supplies}", alignment: Alignment.LeftAligned);
            fSBs[0].AddFreeString($"Demand(s):{demands}", alignment: Alignment.LeftAligned);
            fSBs[0].AddFreeString($"Fuel Price: {objH.player.currentPlanet.fuelPrice}", alignment: Alignment.LeftAligned);


            fSBs.Add(new FreeStringBundle(27, edge + 55, 200));
            fSBs[1].AddFreeString($"WrapFactor: {objH.player.wrapFactor}", alignment: Alignment.LeftAligned);
            fSBs[1].AddFreeString($"Speed: {objH.player.GetSpeed()}", alignment: Alignment.LeftAligned);
            fSBs[1].AddFreeString($"Current Fuel LeveL: {objH.player.GetFuelLevel()}", alignment: Alignment.LeftAligned);
            fSBs[1].AddFreeString($"Age: {objH.player.GetAge()}", alignment: Alignment.LeftAligned);


            fSBs.Add(new FreeStringBundle(27, edge + 95, 200));
            fSBs[2].AddFreeString($"Money: {objH.player.money}", alignment: Alignment.LeftAligned);


            foreach (BoundaryBox box in boxs)
            {
                box.Print();
            }

            foreach (FreeStringBundle fSB in fSBs)
            {
                fSB.Print();
            }


            Menu main = new Menu(27, edge + 3, menuStyle: BoxStyle.Limited, width: 15);
            main.AddItem(new MenuItem("Travel", Alignment.Centered, MenuPart.MenuItemSelected));
            main.AddItem(new MenuItem("Refuel", Alignment.Centered, MenuPart.MenuItem));
            main.AddItem(new MenuItem("Shop", Alignment.Centered, MenuPart.MenuItem));
            main.AddItem(new MenuItem("Inventory", Alignment.Centered, MenuPart.MenuItem));
            //main.AddItem(new MenuItem("Upgrade", Alignment.Centered, MenuPart.MenuItem));

            int selection = main.EnterMenuLoop();

            switch (selection)
            {
                case 0:
                    return Pages.Travel;
                case 1:
                    objH.player.refuel();
                    return Pages.Ship;
                case 2:
                    return Pages.Shop;
                case 3:
                    return Pages.Inventory;
                case 4:
                    return Pages.Upgrade;
            }


            return Pages.Ship;
        }

        public Pages Travel()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("Travel");
            titleBox.Print();

            List<BoundaryBox> boxs = new List<BoundaryBox>();
            boxs.Add(new BoundaryBox(25, edge, new XYPair(69, 20), Alignment.RightAligned));
            boxs.Add(new BoundaryBox(25, edge, new XYPair(50, 20), Alignment.LeftAligned));
            boxs.Add(new BoundaryBox(5, edge, new XYPair(60, 20), Alignment.RightAligned));
            titleBox.Print();

            List<FreeStringBundle> fSBs = new List<FreeStringBundle>();
            fSBs.Add(new FreeStringBundle(9, edge + 63, 200));
            string supplies = objH.player.currentPlanet.supplies;

            fSBs.Add(new FreeStringBundle(27, edge + 55, 200));
            fSBs[1].AddFreeString($"WrapFactor: {objH.player.wrapFactor}", alignment: Alignment.LeftAligned);
            fSBs[1].AddFreeString($"Speed: {objH.player.GetSpeed()}", alignment: Alignment.LeftAligned);
            fSBs[1].AddFreeString($"Current Fuel LeveL: {objH.player.GetFuelLevel()}", alignment: Alignment.LeftAligned);
            fSBs[1].AddFreeString($"Age: {objH.player.GetAge()}", alignment: Alignment.LeftAligned);


            fSBs.Add(new FreeStringBundle(27, edge + 95, 200));
            fSBs[2].AddFreeString($"Money: {objH.player.money}", alignment: Alignment.LeftAligned);


            foreach (BoundaryBox box in boxs)
            {
                box.Print();
            }

            foreach (FreeStringBundle fSB in fSBs)
            {
                fSB.Print();
            }

            List<Planet> planetsInReach = objH.player.GetPlanetWithinReach();

            Menu travelTo = new Menu(27, edge + 3, maxShown: 9, menuStyle: BoxStyle.Limited, width: 30);
            foreach (Planet p in planetsInReach)
            {
                if (p != objH.player.currentPlanet) 
                travelTo.AddItem(new MenuItem(p.name));
            }
            travelTo.SetEntryPoint(0);

            int selection = 0;
            bool done = false;
            while (!done)
            {
                double distance = planetsInReach[travelTo.ReturnIndex()].location - objH.player.currentPlanet.location;
                string demands = objH.player.currentPlanet.demands;
                fSBs[0].ClearContent();
                fSBs[0].AddFreeString($"Current Selected Planet Location: {planetsInReach[travelTo.ReturnIndex()]}", alignment: Alignment.LeftAligned);
                fSBs[0].AddFreeString($"Supply(s):{planetsInReach[travelTo.ReturnIndex()].supplies}", alignment: Alignment.LeftAligned);
                fSBs[0].AddFreeString($"Demand(s):{planetsInReach[travelTo.ReturnIndex()].demands}", alignment: Alignment.LeftAligned);
                fSBs[0].AddFreeString($"Fuel Price: {planetsInReach[travelTo.ReturnIndex()].fuelPrice}", alignment: Alignment.LeftAligned);
                fSBs[0].AddFreeString($"Distance From Current Planet: {distance}", alignment: Alignment.LeftAligned);
                fSBs[0].Print();

                travelTo.Print();

                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        travelTo.ItemUp();
                        break;
                    case ConsoleKey.DownArrow:
                        travelTo.ItemDown();
                        break;
                    case ConsoleKey.Enter:
                        selection = travelTo.ReturnIndex();
                        done = true;
                        break;
                    default:
                        break;
                }
                

            }

            objH.player.setPlanet(planetsInReach[selection]);

            return Pages.Ship;
        }

        public Pages Inventory()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("Inventory");
            titleBox.Print();

            BoundaryBox box = new BoundaryBox(10, edge, new XYPair(66, 35), Alignment.LeftAligned);
            box.Print();

            objH.PrintImage(new XYPair(edge + 68, 15), "Pikachu");

            Menu inventoryMenu = new Menu(27, edge + 3, maxShown: 20, menuStyle: BoxStyle.Limited, width: 60);
            foreach (InventoryItem item in objH.player.inventory)
            {
                inventoryMenu.AddItem(new MenuItem(Calc.GetInventoryDisplay(item)));
            }

            inventoryMenu.SetEntryPoint(0);
            int selection = inventoryMenu.EnterMenuLoop();

            return Pages.Ship;
        }

        public Pages Shop()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("SHOP");
            titleBox.Print();


            BoundaryBox welcomeBox = new BoundaryBox(25, new XYPair(50, 10), Alignment.Centered);

            FreeStringBundle welcomeMessage = new FreeStringBundle(26, edge + 40, 200);
            welcomeMessage.AddFreeString("Welcome, Dear Customer!", alignment: Alignment.LeftAligned);
            welcomeMessage.AddFreeString("What would you like to do today!", alignment: Alignment.LeftAligned);

            Menu buyOrSale = new Menu(29, menuStyle: BoxStyle.Limited, _alignment: Alignment.Centered, width: 5);
            buyOrSale.AddItem(new MenuItem("Buy", Alignment.Centered));
            buyOrSale.AddItem(new MenuItem("Sale", Alignment.Centered));
            buyOrSale.AddItem(new MenuItem("Exit", Alignment.Centered));

            welcomeBox.Print();
            welcomeMessage.Print();
            buyOrSale.SetEntryPoint(0);
            int choice = buyOrSale.EnterMenuLoop();
            switch (choice)
            {
                case 0:
                    return Pages.Buy;
                case 1:
                    return Pages.Sale;
                case 2:
                    return Pages.Ship;
                default:
                    break;
            }

            return Pages.Ship;
        }

        public Pages Buy()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("Buy");
            titleBox.Print();

            BoundaryBox box = new BoundaryBox(25, edge, new XYPair(66, 20), Alignment.LeftAligned);
            box.Print();

            objH.PrintImage(new XYPair(edge + 68, 15), "ShopKeeper");

            Menu buyShop = new Menu(27, edge + 3, maxShown: 9, menuStyle: BoxStyle.Limited, width: 60);
            foreach (ShopItem item in objH.player.currentPlanet.supplyShop)
            {
                buyShop.AddItem(new MenuItem(Calc.GetShopDisplay(item)));
            }

            buyShop.SetEntryPoint(0);
            int selection = buyShop.EnterMenuLoop();

            FreeString wouldLiketoBuy = new FreeString(new XYPair(edge + 3, 38), "How many would you like to buy?");
            int maxAmount = objH.player.money / objH.player.currentPlanet.supplyShop[selection].GetPrice();
            Numbers amount = new Numbers(3, new XYPair(edge + 4, 40), maxAmount);
            wouldLiketoBuy.Print();
            int amountBought = amount.EnterMainLoop();
            objH.player.Buy(objH.player.currentPlanet.supplyShop[selection], amountBought);
            return Pages.Shop;
        }

        public Pages Sale()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("Sale");
            titleBox.Print();

            BoundaryBox box = new BoundaryBox(25, edge, new XYPair(66, 20), Alignment.LeftAligned);
            box.Print();

            objH.PrintImage(new XYPair(edge + 68, 15), "ShopKeeper");

            Menu saleShop = new Menu(27, edge + 3, maxShown: 9, menuStyle: BoxStyle.Limited, width: 60);
            foreach (ShopItem item in objH.player.currentPlanet.demandShop)
            {
                if (objH.player.inventory.Any(i => i.index == item.GetIndex()))
                saleShop.AddItem(new MenuItem(Calc.GetShopDisplay(item)));
            }

            saleShop.SetEntryPoint(0);
            int selection = saleShop.EnterMenuLoop();

            FreeString wouldLiketoSale = new FreeString(new XYPair(edge + 3, 38), "How many would you like to Sale?");
            Numbers amount = new Numbers(3, new XYPair(edge + 4, 40));
            wouldLiketoSale.Print();
            int amountSold = amount.EnterMainLoop();
            objH.player.Sale(objH.player.currentPlanet.demandShop[selection], amountSold);
            return Pages.Shop;
        }

        public Pages TestPage()
        {
            Console.Clear();

            FreeStringList sh = new FreeStringList();
            Menu scrollableTest = new Menu(20, 20, 10, "Shop", width: 10, menuStyle: BoxStyle.Limited);
            BoundaryBox box = new BoundaryBox(new XYPair(19, 19), new XYPair(15, 12));
            for (int i = 0; i < 20; i++)
            {
                scrollableTest.AddItem(new MenuItem($"Shop Item {i}"));
            }


            objH.PrintImage(new XYPair(40, 5), "Pikachu");
            box.Print();
            int digits = scrollableTest.EnterMenuLoop();


            Numbers number = new Numbers(digits, new XYPair(40, 25));
            int result = number.EnterMainLoop();


            StringRenderer.PrintFreeString(new FreeString(20, result.ToString()));
            Console.Read();

            return Pages.TestPage;
        }


    }
}
