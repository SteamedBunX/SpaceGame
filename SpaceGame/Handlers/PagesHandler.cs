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
            objH.GenerateNewData();
            StringHandler s = new StringHandler();
            s.AddStyledString("What is your name?", alignment: TextAlignment.Centered, lyr:1);
            s.InsertLineSkip(0, 25);
            s.PrintStringBitmap();
            s.ClearStringBitmap();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.CursorTop + 1);
            string playerName = Console.ReadLine();
            s.AddStyledString("What is your gender?", alignment: TextAlignment.Centered);
            s.PrintStringBitmap();
            s.ClearStringBitmap();
            string gender = Console.ReadLine();
            s.AddStyledString("Welcome, Adnventurer", alignment: TextAlignment.Centered);
            s.PrintStringBitmap();



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
            StringHandler sh = new StringHandler();
            sh.AddStyledString("~~~~~The Space GAME~~~~~", lyr: 1, alignment: TextAlignment.Centered);
            sh.AddStyledString("~~~~~~~~Made by 2 men team~~~~~~~~", lyr: 1, alignment: TextAlignment.Centered);
            sh.InsertLineSkip(0, 15);
            sh.PrintStringBitmap();


            menuH.TestMenu();
            return Pages.TestPage;
        }
    }
}
