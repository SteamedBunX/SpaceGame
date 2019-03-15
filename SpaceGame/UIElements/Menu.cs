using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Menu
    {
        public int firstRow, columnStart, columnEnd;
        public MenuStyle style = MenuStyle.FullSize;
        public List<MenuItem> menuItems = new List<MenuItem>();
        public Menu(int row, MenuStyle menuStyle = MenuStyle.FullSize, int start = 0, int end = 0)
        {
            firstRow = row;
            style = menuStyle;
            columnStart = start;
            columnEnd = end;
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
            MenuItem lastVer = menuItems[index];
            menuItems[index] = new MenuItem(lastVer.itemName,part, lastVer.alignment);
        }
    }
}
