using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.UIElements
{
    class Menu
    {
        MenuStyle style = MenuStyle.FullSize;
        List<MenuItem> menuItems = new List<MenuItem>();
        public void AddItem(MenuItem item)
        {
            menuItems.Add(item);
        }

        public void clearItems()
        {
            menuItems.Clear();
        }
    }
}
