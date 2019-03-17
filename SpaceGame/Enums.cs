using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{

    public enum Pages { MainMenu, LoadSave, NewCharacter, Ship, Credits, Nevigate, Exit, PlaceHolder, TestPage }
    public enum TextColor { Black, White, Red, Yellow }
    public enum MenuPart { Title, MenuItem, MenuItemSelected, MenuItemPrompt}
    public enum BoxStyle { Limited, FullSize }
    public enum Alignment { LeftAligned, Centered, RightAligned, Free }
    public enum Gender { Male, Female}

}
