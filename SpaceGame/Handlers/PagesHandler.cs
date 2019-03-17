using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
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
            int i = menuH.MainPageMenu();
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
            DialogBox box = new DialogBox(20, new XYPair(24, 7));
            box.Print();
            fSB.print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string playerName = Console.ReadLine();


            Console.Clear();
            fSB.ClearContent();

            fSB.AddFreeString($"Ok, {playerName}");
            fSB.AddFreeString("what is your gender?");
            XYPair bgSize = new XYPair(24, 7);
            Menu menu = new Menu(24);
            menu.AddItem(new MenuItem("Male", Alignment.Centered));
            menu.AddItem(new MenuItem("Female", Alignment.Centered));
            menu.SetEntryPoint(0);
            box.Print();
            fSB.print();
            Gender playerGender = menu.EnterMenuLoop() == 0? Gender.Male : Gender.Female;
            box.Print();
            fSB.print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string gender = playerGender.ToString();
            objH.player = new Player(playerName, playerGender);



            Console.Clear();
            fSB.ClearContent();
            fSB.AddFreeString($"Your Name is {playerName}");
            fSB.AddFreeString($"Your Gender is {gender}");
            box.Print();
            fSB.print();
            Console.ReadLine();

            //objH.GenerateNewData();
            return Pages.MainMenu;
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



        internal Pages TestPage()
        {
            FreeStringList sh = new FreeStringList();
            menuH.TestMenu();
            return Pages.TestPage;
        }
    }
}
