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
            menu.AddItem(new MenuItem("New Game", MenuPart.MenuItem, TextAlignment.Centered));
            menu.AddItem(new MenuItem("Load Data", MenuPart.MenuItemSelected, TextAlignment.Centered));
            menu.AddItem(new MenuItem("Credit", MenuPart.MenuItem, TextAlignment.Centered));
            menu.AddItem(new MenuItem("Exit", MenuPart.MenuItem, TextAlignment.Centered));
            menu.SetEntryPoint(2);
            menu.SetBorder(20);
            while (true)
            {
                MenuRenderer.PrintMenu(menu);
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        menu.ItemUp();
                        break;
                    case ConsoleKey.DownArrow:
                        menu.ItemDown();
                        break;
                    case ConsoleKey.Enter:
                        return menu.currentSelection;
                    default:
                        break;
                }
                
                

            }
        }

        public void TestMenu()
        {
            XYPair bgSize = new XYPair(10, 4);
            Menu testMenu = new Menu(30);
            testMenu.AddItem(new MenuItem("Item 1", MenuPart.MenuItemSelected, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 2", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 3", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 4", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 5", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 6", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 7", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.AddItem(new MenuItem("Item 8", MenuPart.MenuItem, TextAlignment.Centered));
            testMenu.SetBorder(20);
            MenuRenderer.PrintMenu(testMenu);
            while (true)
            {
                testMenu.SetBorder(20);
                MenuRenderer.PrintMenu(testMenu);
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                            testMenu.ItemUp();
                        break;
                    case ConsoleKey.DownArrow:
                            testMenu.ItemDown();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
