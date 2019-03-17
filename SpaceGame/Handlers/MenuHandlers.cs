using System;
using Console = Colorful.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    public class MenuHandlers
    {
        ObjectHandler objH;
        public MenuHandlers(ref ObjectHandler _objH)
        {
            objH = _objH;
        }
        public int MainPageMenu()
        {
            XYPair bgSize = new XYPair(10, 4);
            Menu menu = new Menu(30);
            menu.AddItem(new MenuItem("New Game", Alignment.Centered));
            menu.AddItem(new MenuItem("Load Data", Alignment.Centered));
            menu.AddItem(new MenuItem("Credit", Alignment.Centered));
            menu.AddItem(new MenuItem("Exit", Alignment.Centered));
            menu.SetEntryPoint(1);
            menu.SetBorder(20);
            return menu.EnterMenuLoop();
        }




        public int TestMenu()
        {
            XYPair bgSize = new XYPair(10, 4);
            Menu testMenu = new Menu(30);
            testMenu.AddItem(new MenuItem("Item 1", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 2", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 3", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 4", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 5", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 6", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 7", Alignment.Centered));
            testMenu.AddItem(new MenuItem("Item 8", Alignment.Centered));
            testMenu.SetBorder(20);
            return testMenu.EnterMenuLoop();
        }
    }
}
