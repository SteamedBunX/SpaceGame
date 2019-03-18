using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    [System.Runtime.InteropServices.Guid("120EBD72-5878-464C-AABA-65DFC6F6F6DA")]
    public class PagesHundler
    {
        ObjectHandler objH;
        MenuHandlers menuH;


        public PagesHundler(ref ObjectHandler _objH)
        {
            objH = _objH;
            menuH = new MenuHandlers(ref objH);
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
            objH.printImage(new Coordi(35, 5), "Logo.ci");
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
            fSB.print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
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
            fSB.print();
            Gender playerGender = menu.EnterMenuLoop() == 0 ? Gender.Male : Gender.Female;
            box.Print();
            fSB.print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string gender = playerGender.ToString();
            objH.player = new Player(playerName, playerGender);



            Console.Clear();
            bgSize = new XYPair(35, 7);
            box.SetSize(bgSize);
            fSB.ClearContent();
            fSB.AddFreeString($"Your Name is {playerName}");
            fSB.AddFreeString($"Your Gender is {gender}");
            fSB.AddFreeString($"Press Enter to find your home");
            box.Print();
            fSB.print();
            Console.ReadLine();

            objH.GenerateNewData();




            return Pages.Ship;
        }

        public Pages Ship()
        {
            Console.Clear();
            TitleBox titleBox = new TitleBox("SHIP");
            List<BoundaryBox> boxs = new List<BoundaryBox>();
            boxs.Add(new BoundaryBox(25, new XYPair(60, 20), Alignment.RightAligned));
            boxs.Add(new BoundaryBox(25, 60, new XYPair(60, 20), Alignment.RightAligned));
            titleBox.Print();
            foreach (BoundaryBox box in boxs)
            {
                box.Print();
            }

            Console.Read();


            return Pages.Ship;
        }

        public Pages LoadMenu()
        {
            return Pages.PlaceHolder;
        }

        public Pages SaveMenu()
        {
            return Pages.PlaceHolder;
        }

        public Pages Shop()
        {
            return Pages.PlaceHolder;
        }

        public Pages TestPage()
        {
            objH.printImage(new Coordi(40,5),"Logo.ci");




            FreeStringList sh = new FreeStringList();
            Menu scrollableTest = new Menu(20, 20, 10, "Shop", _width: 10,menuStyle: BoxStyle.Limited);
            BoundaryBox box = new BoundaryBox(new Coordi(19, 19), new XYPair(15, 12));
            for (int i = 0; i < 20; i++)
            {
                scrollableTest.AddItem(new MenuItem($"Shop Item {i}"));
            }
            box.Print();
            scrollableTest.EnterMenuLoop();
            return Pages.TestPage;
        }


    }
}
