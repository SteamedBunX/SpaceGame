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
            MenuHandlers m = new MenuHandlers();
            m.TestMenu();
            return Pages.TestPage;
        }
    }
}
