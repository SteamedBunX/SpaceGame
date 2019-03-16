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
                            PrintSelectedMenuItem(currentRow, middleColumn, item);
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

        public static void PrintSelectedMenuItem(int currentRow, int middleColumn, MenuItem item)
        {
            switch (item.alignment)
            {
                case TextAlignment.LeftAligned:
                    StringRenderer.PrintAugmentingString(new XYPair(currentRow, 0),
                         Color.White, Color.Black, item.itemName);
                    break;
                case TextAlignment.Centered:
                    StringRenderer.PrintAugmentingString(new XYPair(currentRow, middleColumn - item.itemName.Length / 2),
                         Color.White, Color.Black, item.itemName);
                    break;
                case TextAlignment.RightAligned:
                    StringRenderer.PrintAugmentingString(new XYPair(currentRow, middleColumn * 2 - item.itemName.Length),
                         Color.White, Color.Black, item.itemName);
                    break;
                default:
                    break;
            }
        }

        public static void PrintMenuItem(MenuItem item, int currentRow, int middleColumn)
        {
            switch (item.alignment)
            {
                case TextAlignment.LeftAligned:
                    StringRenderer.PrintAugmentingString(new XYPair(currentRow, 0),
                         Color.Black, Color.White, item.itemName);
                    break;
                case TextAlignment.Centered:
                    StringRenderer.PrintAugmentingString(new XYPair(currentRow, middleColumn - item.itemName.Length / 2),
                         Color.Black, Color.White, item.itemName);
                    break;
                case TextAlignment.RightAligned:
                    StringRenderer.PrintAugmentingString(new XYPair(currentRow, middleColumn * 2 - item.itemName.Length),
                         Color.Black, Color.White, item.itemName);
                    break;
                default:
                    break;
            }
        }



    }
}
