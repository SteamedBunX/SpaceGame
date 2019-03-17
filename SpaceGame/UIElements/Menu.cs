using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Menu
    {
        public int currentSelection = 0;
        public bool hasTitle = false;
        public bool hasBorder = false;
        public bool hasBG = false;
        public Border bg;
        public Border border;
        public string title = "";
        public Alignment titleAlignment;
        public int firstRow, columnStart, columnWidth;
        public BoxStyle style;
        public List<MenuItem> menuItems = new List<MenuItem>();
        public Menu(int row, string _title = "",
            BoxStyle menuStyle = BoxStyle.FullSize, int start = 0, int _width = 0)
        {

            firstRow = row;
            style = menuStyle;
            columnStart = start;
            columnWidth = _width;
            if (_title != "")
            {
                title = _title;
                hasTitle = true;
            }
        }

        public int EnterMenuLoop()
        {
            while (true)
            {
                MenuRenderer.PrintMenu(this);
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        ItemUp();
                        break;
                    case ConsoleKey.DownArrow:
                        ItemDown();
                        break;
                    case ConsoleKey.Enter:
                        return ReturnIndex();
                    default:
                        break;
                }
            }
        }

        public void SetEntryPoint(int index)
        {
            currentSelection = index;
            menuItems[index].Select();
        }

        public void SetBG(XYPair size, Coordi position)
        {
            hasBG = true;
            bg = new Border(size, position);
        }

        public void SetBG(int lineSize)
        {
            hasBG = true;
            columnWidth = lineSize;
            XYPair size = new XYPair(lineSize, menuItems.Count);
            int startingColumn = style == BoxStyle.FullSize ? (Console.WindowWidth - columnWidth) / 2 : columnStart + columnWidth / 2;
            Coordi position = new Coordi(startingColumn, firstRow);
            bg = new Border(size, position);
        }

        public void SetBorder(XYPair size, Coordi position)
        {
            hasBorder = true;
            border = new Border(size, position);
        }

        public void SetBorder(int lineSize)
        {
            columnWidth = lineSize;
            hasBorder = true;
            XYPair size = new XYPair(lineSize + 2, hasTitle ? menuItems.Count + 3 : menuItems.Count + 2);
            int startingColumn = style == BoxStyle.FullSize ? (Console.WindowWidth - columnWidth) / 2 - 2 : columnStart - 1;
            Coordi position = new Coordi(startingColumn, hasTitle ? firstRow - 2 : firstRow - 1);
            border = new Border(size, position);
        }

        public void SetTitle(string titleText, Alignment alignment = Alignment.Centered)
        {
            title = titleText;
            titleAlignment = alignment;
        }

        public void AddItem(MenuItem item)
        {
            menuItems.Add(item);
            if (!hasBorder)
            {
                if (columnWidth < item.itemName.Length)
                {
                    columnWidth = item.itemName.Length;
                }
            }

        }

        public void clearItems()
        {
            menuItems.Clear();
        }

        public void changeStatus(int index, MenuPart part)
        {
            menuItems[index].menuPart = part;
        }

        public void Unselect(int index)
        {
            menuItems[index].Unselect();
        }

        public void Select(int index)
        {
            menuItems[index].Select();
        }

        public void ItemUp()
        {
            if (currentSelection > 0)
            {
                Unselect(currentSelection);
                currentSelection--;
                Select(currentSelection);
            }
        }

        public void ItemDown()
        {
            if (currentSelection < menuItems.Count - 1)
            {
                Unselect(currentSelection);
                currentSelection++;
                Select(currentSelection);
            }
        }

        public int ReturnIndex()
        {
            return currentSelection;
        }
    }
}
