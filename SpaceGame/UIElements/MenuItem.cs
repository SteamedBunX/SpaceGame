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
        public TextAlignment alignment;
        public MenuItem(string _itemName, MenuPart _menuPart, TextAlignment _alignment)
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
