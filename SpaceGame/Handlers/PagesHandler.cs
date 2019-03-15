using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class PagesHundler
    {
        new ObjectHandler objH;
        public PagesHundler(ref ObjectHandler _objH)
        {
            objH = _objH;
        }

        public Pages MainMenu()
        {
            MenuHandlers m = new MenuHandlers();
            m.MainPageMenu();
            return Pages.MainMenu;
        }

        public Pages CreateNewData()
        {
            return Pages.PlaceHolder;
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
            sh.AddStyledString("The Space GAME~~~~~", lyr: 1, alignment: TextAlignment.Centered);
            sh.AddStyledString("Made by 2 men team~~~~~~~~", lyr: 1, alignment: TextAlignment.Centered);
            sh.InsertLineSkip(0, 15);
            sh.PrintStringBitmap();


            MenuHandlers m = new MenuHandlers();
            m.TestMenu();
            return Pages.TestPage;
        }
    }
}
