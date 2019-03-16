using System;
using Console = Colorful.Console;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class MenuRenderer
    {
        public static void PrintMenu(Menu menu)
        {
            if (menu.hasBorder)
            {
                GraphicRenderer.PrintBorder(menu.border);
            }
            int currentRow = menu.firstRow;
            if (menu.style == BoxStyle.FullSize)
            {
                int middleColumn = Console.WindowWidth / 2;
                foreach (MenuItem item in menu.menuItems)
                {
                    switch (item.menuPart)
                    {
                        case MenuPart.MenuItem:
                            PrintMenuItem(item, currentRow, middleColumn);
                            break;
                        case MenuPart.MenuItemSelected:
                            PrintSelectedMenuItem(item, currentRow, middleColumn);
                            break;
                        case MenuPart.MenuItemPrompt:
                            break;
                        default:
                            break;
                    }
                    currentRow++;
                }
            }
            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public static void PrintSelectedMenuItem(MenuItem item, int currentRow, int middleColumn)
        {
            XYPair position;
            switch (item.alignment)
            {
                case Alignment.LeftAligned:
                    position = new XYPair(0, currentRow);
                    break;
                case Alignment.Centered:
                    position = new XYPair(middleColumn - item.itemName.Length / 2, currentRow);
                    break;
                default:
                    position = new XYPair(middleColumn * 2 - item.itemName.Length, currentRow);
                    break;

            }
            StringRenderer.PrintFreeString(new FreeString(position, item.itemName, TextColor.Black, TextColor.White));
        }

        public static void PrintMenuItem(MenuItem item, int currentRow, int middleColumn)
        {
            XYPair position;
            switch (item.alignment)
            {
                case Alignment.LeftAligned:
                    position = new XYPair(0, currentRow);
                    break;
                case Alignment.Centered:
                    position = new XYPair(middleColumn - item.itemName.Length / 2, currentRow);
                    break;
                default:
                    position = new XYPair(middleColumn * 2 - item.itemName.Length, currentRow);
                    break;

            }
            StringRenderer.PrintFreeString(new FreeString(position, item.itemName));
        }



    }
}
