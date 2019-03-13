using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class PagesHundler
    {
        new ObjectHandler objH;
        public PagesHundler(ref ObjectHandler _objH)
        {
            objH = _objH;
        }

        public Pages MainMenu()
        {
            Console.WriteLine("Please select your page :\n" +
                "1: Starting a new Game\n" +
                "2: Load Save File\n" +
                "3: Credits");
            string choice = Console.ReadLine();
            switch(choice)
            {
                case "1":
                    return Pages.NewCharacter;
                case "2":
                    return Pages.LoadSave;
                case "3":
                    return Pages.Credits;
            }
            return Pages.MainMenu;
        }

        public Pages CreateNewData()
        {
            return Pages.PlaceHolder;
        }

        public Pages LoadMenu()
        {
            return Pages.PlaceHolder;
        }

        public Pages SaveMenu()
        {
            return Pages.PlaceHolder;
        }

        public Pages Shop()
        {
            return Pages.PlaceHolder;
        }


    }
}
