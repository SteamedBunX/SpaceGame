using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpaceGame
{
    class Program
    {


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }
        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int SetConsoleFont(
            IntPtr hOut,
            uint dwFontNum
            );
        public static void SetConsoleFont(short x, short y, string fontName = "MS Gothic")
        {
            unsafe
            {
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                if (hnd != INVALID_HANDLE_VALUE)
                {
                    CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    // Set console font to Lucida Console.
                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    // Get some settings from current font.
                    COORD fontSize = new COORD(x, y);
                    newInfo.dwFontSize = fontSize;

                    newInfo.FontWeight = 700;
                    SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }




        // Starting the console in full screen
        // https://stackoverflow.com/questions/4423085/c-sharp-full-screen-console 
        internal static class DllImports
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct COORD
            {

                public short X;
                public short Y;
                public COORD(short x, short y)
                {
                    this.X = x;
                    this.Y = y;
                }

            }
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetStdHandle(int handle);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetConsoleDisplayMode(
                IntPtr ConsoleOutput
                , uint Flags
                , out COORD NewScreenBufferDimensions
                );

        }







        static void Main(string[] args)
        {
            SetConsole();
            Game g = new Game();
            g.Ini();
            g.Run();

        }

        //static void TestingDraw()
        //{
        //    Random r = new Random();

        //    for (int i = 1; i <= 50; i++)
        //    {
        //        Console.Write("");
        //        for (int j = 1; j <= 20; j++)
        //        {
        //            Console.BackgroundColor = (ConsoleColor)r.Next(15);
        //            Console.ForegroundColor = (ConsoleColor)r.Next(15);

        //            Console.Write("▀");
        //            Console.ResetColor();
        //        }
        //        Console.WriteLine(i);

        //    }
        //    Console.ResetColor();
        //    for (int i = 1; i <= 5; i++)
        //    {
        //        Console.WriteLine(i);
        //    }

        //    Console.Read();
        //    //Game g = new Game();
        //    //g.Ini();
        //    //g.Run();


        //}


        static void SetConsole()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            short width = (short)(resolution.Height / 50 / 2);
            short height = (short)(resolution.Height / 50);
            SetConsoleFont(width, height, "Consolas");
            IntPtr hConsole = DllImports.GetStdHandle(-11);   // get console handle
            DllImports.COORD xy = new DllImports.COORD(100, 100);
            DllImports.SetConsoleDisplayMode(hConsole, 1, out xy);
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.BufferHeight = Console.LargestWindowHeight;
        }


    }
}
