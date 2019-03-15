using System;
using Console = Colorful.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceGame
{
    class MenuHandlers
    {
        public void MainPageMenu()
        {
            XYPair bgSize = new XYPair(10,4);
            Menu mainMenu = new Menu(30);
            int currentSelection = 1;
            mainMenu.AddItem(new MenuItem("New Game", MenuPart.MenuItemSelected, TextAlignment.Centered));
            mainMenu.AddItem(new MenuItem("Load Save", MenuPart.MenuItem, TextAlignment.Centered));
            mainMenu.AddItem(new MenuItem("Credit", MenuPart.MenuItem, TextAlignment.Centered));
            mainMenu.AddItem(new MenuItem("Exit", MenuPart.MenuItem, TextAlignment.Centered));
            while (true)
            {
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        if (currentSelection > 1)
                        {
                            mainMenu.Unselect(currentSelection - 1);
                            currentSelection--;
                            mainMenu.Select(currentSelection - 1);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentSelection < 4)
                        {
                            mainMenu.Unselect(currentSelection - 1);
                            currentSelection++;
                            mainMenu.Select(currentSelection - 1);
                        }
                        break;
                    default:
                        break;
                }
                MenuRenderer.PrintMenu(mainMenu);

            }
        }

        public void TestMenu()
        {
            XYPair bgSize = new XYPair(10, 4);
            Menu testMenu = new Menu(30);
            int currentSelection = 1;
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
