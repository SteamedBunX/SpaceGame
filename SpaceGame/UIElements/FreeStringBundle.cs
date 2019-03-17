using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class FreeStringBundle
    {
        public int startRow, startColumn, endColumn;
        public List<FreeString> content = new List<FreeString>();

        public FreeStringBundle(int row)
        {
            startRow = row;
            startColumn = 0;
            endColumn = Console.WindowWidth;
        }

        public FreeStringBundle(int row, int leftLimit, int rightLimit)
        {
            startRow = row;
            startColumn = leftLimit;
            endColumn = rightLimit;
        }

        public void AddFreeString(string t,
           TextColor tColor = TextColor.White, TextColor bColor = TextColor.Black,
           Alignment alignment = Alignment.Centered)
        {
            int currentRow = startRow + content.Count;
            int startingPoint = startColumn;
            int width = endColumn - startColumn;
            int temp;
            switch (alignment)
            {
                case Alignment.Centered:
                    temp = (width - t.Count()) / 2 - 1;
                    startingPoint += temp > 0 ? temp : 0;
                    break;
                case Alignment.RightAligned:
                    startingPoint += width - t.Count();
                    break;
            }
            content.Add(new FreeString(new XYPair(startingPoint, currentRow), t,
                tColor, bColor, alignment: Alignment.Free));
        }

        public void ClearContent()
        {
            content.Clear();
        }

        public void ResetBorder(int row, int leftLimit, int rightLimit)
        {
            startRow = row;
            startColumn = leftLimit;
            endColumn = rightLimit;
        }

        public void print()
        {
            StringRenderer.PrintFreeStringBundle(this);
        }

    }
}
