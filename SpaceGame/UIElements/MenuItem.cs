using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class MenuItem
    {

        public string itemName;
        public MenuPart menuPart;
        public Alignment alignment;
        public MenuItem(string _itemName, Alignment _alignment = Alignment.LeftAligned, MenuPart _menuPart = MenuPart.MenuItem)
        {
            itemName = _itemName;
            menuPart = _menuPart;
            alignment = _alignment;
        }

        public void Select()
        {
            menuPart = MenuPart.MenuItemSelected;
        }

        public void Unselect()
        {
            menuPart = MenuPart.MenuItem;
        }



    }

}
