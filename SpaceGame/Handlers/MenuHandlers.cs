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
            return testMenu.EnterMenuLoop();
        }
    }
}
