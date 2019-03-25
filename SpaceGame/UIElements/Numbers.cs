using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class Numbers
    {
        public int currentDigit = 0;
        public int digits;
        public List<Number> numbers = new List<Number>();
        public int positionX, positionY;
        public int max = 0;
        public Numbers(int _digits, XYPair position)
        {
            positionX = position.x;
            positionY = position.y;
            digits = _digits;
            if (digits < 1)
            {
                digits = 1;
            }
            for (int i = 0; i < digits; i++)
            {
                numbers.Add(new Number());
                max += (int)(Math.Pow(10, i)) * 9;
            }


        }

        public Numbers(int _digits, XYPair position, int max)
        {
            positionX = position.x;
            positionY = position.y;
            digits = _digits;
            if (digits < 1)
            {
                digits = 1;
            }
            for (int i = 0; i < digits; i++)
            {
                numbers.Add(new Number());
            }
            this.max = max;
        }

        public int getDigit(int index)
        {
            return numbers[index].i;
        }

        public int EnterMainLoop()
        {
            bool done = false;
            while (!done)
            {
                MenuRenderer.PrintNumbers(this, positionY, positionX);
                bool overflow = false;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                    case ConsoleKey.UpArrow:
                        overflow = numbers[currentDigit].Up();
                        CheckMax();
                        break;
                    case ConsoleKey.DownArrow:
                        overflow = numbers[currentDigit].Down();
                        CheckMax();
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentDigit < numbers.Count - 1)
                        {
                            currentDigit++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentDigit > 0)
                        {
                            currentDigit--;
                        }
                        break;
                }


            }

            return GetCurrentValue();

        }

        public void CheckMax()
        {
            if (GetCurrentValue() > max)
            {
                SetNumber(max);
            }

        }

        public void SetNumber(int number)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i].i = number % (int)Math.Pow(10, i+1) / (int)Math.Pow(10,i);
            }
        }

        public int GetCurrentValue()
        {
            int currentValue = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                currentValue += (int)Math.Pow(10.0, i) * numbers[i].i;
            }
            return currentValue;
        }


    }
}
