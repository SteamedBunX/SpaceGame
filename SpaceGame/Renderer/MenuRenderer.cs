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

            int currentRow = menu.firstRow;
            int columnStart = menu.columnStart;
            int middleColumn = 0;
            if (menu.style == BoxStyle.FullSize)
            {
                middleColumn = Console.WindowWidth / 2;
            }
            else
            {
                middleColumn = menu.columnWidth / 2 + columnStart;
            }
            foreach (MenuItem item in menu.menuItems)
            {
                PrintOver(currentRow, menu.columnStart, menu.columnWidth);
                switch (item.menuPart)
                {
                    case MenuPart.MenuItem:
                        PrintMenuItem(item, currentRow, middleColumn, menu.columnStart);
                        break;
                    case MenuPart.MenuItemSelected:
                        PrintSelectedMenuItem(item, currentRow, middleColumn, menu.columnStart);
                        break;
                    case MenuPart.MenuItemPrompt:
                        break;
                    default:
                        break;
                }
                currentRow++;
            }


            Console.ResetColor();
            Console.CursorVisible = false;
        }

        public static void PrintSelectedMenuItem(MenuItem item, int currentRow, int middleColumn, int startColumn)
        {
            XYPair position;
            switch (item.alignment)
            {
                case Alignment.LeftAligned:
                    position = new XYPair(startColumn, currentRow);
                    break;
                case Alignment.Centered:
                    position = new XYPair(middleColumn - item.itemName.Length / 2 - 1, currentRow);
                    break;
                default:
                    position = new XYPair(middleColumn * 2 - item.itemName.Length, currentRow);
                    break;

            }
            StringRenderer.PrintFreeString(new FreeString(position, item.itemName, TextColor.Black, TextColor.White));
        }

        public static void PrintOver(int currentRow, int columnStart, int length)
        {
            Console.SetCursorPosition(columnStart, currentRow);
            Console.BackgroundColor = Color.FromArgb(12,12,12);
            string blank = "";
            for (int i = 0; i < length; i++)
            {
                blank += " ";
            }
            Console.Write(blank);
        }

        public static void PrintMenuItem(MenuItem item, int currentRow, int middleColumn, int startColumn)
        {
            XYPair position;
            switch (item.alignment)
            {
                case Alignment.LeftAligned:
                    position = new XYPair(startColumn, currentRow);
                    break;
                case Alignment.Centered:
                    position = new XYPair(middleColumn - item.itemName.Length / 2 - 1, currentRow);
                    break;
                default:
                    position = new XYPair(middleColumn * 2 - item.itemName.Length, currentRow);
                    break;

            }
            StringRenderer.PrintFreeString(new FreeString(position, item.itemName));
        }

        public static void PrintNumbers(Numbers numbers, int rowStart, int columnStart)
        {
            Console.SetCursorPosition(columnStart, rowStart);
            for (int i = numbers.digits - 1; i >= 0; i--)
            {
                if (i == numbers.currentDigit)
                {
                    Console.BackgroundColor = Color.White;
                    Console.ForegroundColor = Color.FromArgb(12,12,12);
                    Console.Write(numbers.getDigit(i));
                }
                else
                {
                    Console.BackgroundColor = Color.FromArgb(12,12,12);
                    Console.ForegroundColor = Color.White;
                    Console.Write(numbers.getDigit(i));
                }
                Console.BackgroundColor = Color.FromArgb(12,12,12);
                Console.ForegroundColor = Color.White;
            }
            Console.CursorVisible = false;
        }


    }
}
