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
        public void PrintMenu(Menu menu)
        {
            int currentRow = menu.firstRow;
            if (menu.style == MenuStyle.FullSize)
            {
                int middleColumn = Console.WindowWidth / 2;
                foreach (MenuItem item in menu.menuItems)
                {
                    switch (item.part)
                    {
                        case MenuPart.Title:
                            printAugmentingString(new XYPair(currentRow, middleColumn - item.itemName.Length / 2),
                                Color.Yellow, Color.Black, item.itemName);
                            break;
                        case MenuPart.MenuItem:
                            switch (item.alignment)
                            {
                                case TextAlignment.LeftAligned:
                                    printAugmentingString(new XYPair(currentRow, 0),
                                         Color.Black, Color.White, item.itemName);
                                    break;
                                case TextAlignment.Centered:
                                    printAugmentingString(new XYPair(currentRow, middleColumn - item.itemName.Length / 2),
                                         Color.Black, Color.White, item.itemName);
                                    break;
                                case TextAlignment.RightAligned:
                                    printAugmentingString(new XYPair(currentRow, middleColumn * 2 - item.itemName.Length),
                                         Color.Black, Color.White, item.itemName);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case MenuPart.MenuItemSelected:
                            switch (item.alignment)
                            {
                                case TextAlignment.LeftAligned:
                                    Console.SetCursorPosition(0, currentRow);
                                    Console.BackgroundColor = Color.White;
                                    Console.ForegroundColor = Color.Black;
                                    Console.Write(item.itemName);
                                    printAugmentingString(new XYPair(currentRow, 0),
                                         Color.White, Color.Black, item.itemName);
                                    break;
                                case TextAlignment.Centered:
                                    printAugmentingString(new XYPair(currentRow, middleColumn - item.itemName.Length / 2),
                                         Color.White, Color.Black, item.itemName);
                                    break;
                                case TextAlignment.RightAligned:
                                    printAugmentingString(new XYPair(currentRow, middleColumn * 2 - item.itemName.Length),
                                         Color.White, Color.Black, item.itemName);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case MenuPart.MenuItemPrompt:

                            break;
                        default:
                            break;
                    }
                    currentRow++;
                }
            }
        }

        public void MainPageMenu()
        {
            Menu mainMenu = new Menu(30);
            int currentSelection = 1;
            mainMenu.AddItem(new MenuItem("New Game", MenuPart.MenuItem, TextAlignment.Centered));
            mainMenu.AddItem(new MenuItem("Load Save", MenuPart.MenuItemSelected, TextAlignment.Centered));
            mainMenu.AddItem(new MenuItem("Credit", MenuPart.MenuItem, TextAlignment.Centered));
            mainMenu.AddItem(new MenuItem("Exit", MenuPart.MenuItem, TextAlignment.Centered));
            while(true)
            {
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        if(currentSelection > 1)
                        {
                            mainMenu.changeStatus(currentSelection - 1, MenuPart.MenuItem);
                            currentSelection--;
                            mainMenu.changeStatus(currentSelection - 1, MenuPart.MenuItemSelected);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(currentSelection < 4 )
                        {
                            mainMenu.changeStatus(currentSelection - 1, MenuPart.MenuItem);
                            currentSelection++;
                            mainMenu.changeStatus(currentSelection - 1, MenuPart.MenuItemSelected);
                        }
                        break;
                    default:
                        break;
                }
                PrintMenu(mainMenu);
                
            }
        }

        public void printAugmentingString(XYPair cursorPosition, Color bColor, Color fColor, string content)
        {
            Console.SetCursorPosition(cursorPosition.y, cursorPosition.x);
            Console.BackgroundColor = bColor;
            Console.ForegroundColor = fColor;
            Console.Write(content);
        }

    }
}
