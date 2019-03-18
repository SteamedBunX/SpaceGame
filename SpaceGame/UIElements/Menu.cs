using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Menu
    {
        public bool scrollable = false;
        public int top = 0, end = 0;
        public int currentSelection = 0;
        public bool hasTitle = false;
        public bool hasBorder = false;
        public bool hasBG = false;
        public Border bg;
        public Border border;
        public string title = "";
        public Alignment titleAlignment;
        public Alignment alignment;
        public int firstRow, columnStart, columnWidth, maxHeight;
        public BoxStyle style;
        public List<MenuItem> menuItems = new List<MenuItem>();
        public Menu(int row = 0, int column = 0, string _title = "",
            BoxStyle menuStyle = BoxStyle.FullSize, Alignment _alignment = Alignment.Free,
             int _width = 0)
        {
            alignment = _alignment;
            firstRow = row;
            style = menuStyle;
            columnStart = column;
            columnWidth = _width;
            if (_title != "")
            {
                title = _title;
                hasTitle = true;
            }
        }

        public Menu(int row, int column, int maxShown, string _title = "",
    BoxStyle menuStyle = BoxStyle.FullSize, Alignment _alignment = Alignment.Free,
    int _width = 0)
        {
            alignment = _alignment;
            scrollable = true;
            top = 0;
            end = maxShown - 1;
            maxHeight = maxShown;
            firstRow = row;
            style = menuStyle;
            columnStart = column;
            columnWidth = _width;
            if (_title != "")
            {
                title = _title;
                hasTitle = true;
            }
        }


        public void Align()
        {

        }

        public int EnterMenuLoop()
        {
            while (true)
            {
                Print();
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
            if (scrollable && top != 0)
            {
                if (currentSelection <= top + 1)
                {
                    top--;
                    end--;
                }
            }

            if (currentSelection > 0)
            {
                Unselect(currentSelection);
                currentSelection--;
                Select(currentSelection);
            }


        }

        public void ItemDown()
        {
            if (scrollable && end != menuItems.Count - 1)
            {
                if (currentSelection > end - 1)
                {
                    top++;
                    end++;
                }
            }

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

        public void Print()
        {
            if (!scrollable)
            {
                MenuRenderer.PrintMenu(this);
            }
            else
            {
                Menu croped = new Menu(firstRow, columnStart, title, style, _width: columnWidth);
                if (top > 0)
                {
                    croped.AddItem(new MenuItem(@"………", Alignment.Centered));
                }
                else
                {
                    croped.AddItem(menuItems[0]);
                }
                for (int i = top + 1; i < end; i++)
                {
                    croped.AddItem(menuItems[i]);
                }
                if (end < menuItems.Count - 1)
                {
                    croped.AddItem(new MenuItem("………", Alignment.Centered));
                }
                else
                {
                    croped.AddItem(menuItems[end]);
                }
                MenuRenderer.PrintMenu(croped);
            }
            //▲▼
        }
    }
}
