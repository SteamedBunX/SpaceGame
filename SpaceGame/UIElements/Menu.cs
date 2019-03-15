using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Menu
    {
        bool hasTitle = false;
        bool hasBorder = false;
        bool hasBG = false;
        Border bg;
        Border border;
        string title = "";
        TextAlignment titleAlignment;
        public int firstRow, columnStart, columnWidth;
        public MenuStyle style;
        public List<MenuItem> menuItems = new List<MenuItem>();
        public Menu(int row, string _title = "",
            MenuStyle menuStyle = MenuStyle.FullSize, int start = 0, int _width = 0)
        {
            
            firstRow = row;
            style = menuStyle;
            columnStart = start;
            columnWidth = _width;
            if(_title != "")
            {
                title = _title;
                hasTitle = true;
            }
        }

        public void SetBG(XYPair size, Coordi position)
        {
            hasBG = true;
            bg = new Border(size, position);
        }

        public void SetBG(int lineSize)
        {
            hasBG = true;
            XYPair size = new XYPair(lineSize, menuItems.Count);
            int startingColumn = style == MenuStyle.FullSize ? (Console.WindowWidth - columnWidth) / 2 : columnStart + columnWidth / 2;
            Coordi position = new Coordi(startingColumn,firstRow);
            bg = new Border(size, position);
        }

        public void SetBorder(XYPair size, Coordi position)
        {
            hasBorder = true;
            border = new Border(size, position);
        }

        public void SetBorder(int lineSize)
        {
            hasBorder = true;
            XYPair size = new XYPair(lineSize+2, hasTitle ? menuItems.Count+3 : menuItems.Count + 2);
            int startingColumn = style == MenuStyle.FullSize ? (Console.WindowWidth - columnWidth) / 2 - 1: columnStart + columnWidth / 2 - 1;
            Coordi position = new Coordi(startingColumn, hasTitle ? firstRow - 2:firstRow - 1);
            border = new Border(size, position);
        }

        public void SetTitle(string titleText, TextAlignment alignment = TextAlignment.Centered)
        {
            title = titleText;
            titleAlignment = alignment;
        }

        public void AddItem(MenuItem item)
        {
            menuItems.Add(item);
            
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
    }
}
