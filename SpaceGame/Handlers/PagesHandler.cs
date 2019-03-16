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
                case 1:
                    return Pages.NewCharacter;
                default:
                    break;
            }
            
            return Pages.MainMenu;
        }



        public Pages CreateNewData()
        {
            Console.Clear();
            //objH.GenerateNewData();
            FreeStringBundle fSB = new FreeStringBundle(21);
            fSB.AddFreeString("Hello Advanturer");
            fSB.AddFreeString("What is your name?");
            DialogBox box = new DialogBox(20, new XYPair(24,7));
            box.Print();
            fSB.print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string playerName = Console.ReadLine();
            Console.Clear();
            fSB.ClearContent();
            fSB.AddFreeString($"Now tell me {playerName}");
            fSB.AddFreeString("what is your gender?");
            box.Print();
            fSB.print();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string gender = Console.ReadLine();
            Console.Clear();
            fSB.ClearContent();
            fSB.AddFreeString($"Your Name is {playerName}");
            fSB.AddFreeString($"Your Gender is {gender}");
            box.Print();
            fSB.print();
            Console.ReadLine();
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
