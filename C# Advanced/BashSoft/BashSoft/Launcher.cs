using System;

namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            Tester.CompareContent(@"C:\Users\Kristofar Hristov\Desktop\BashSoft-FirstWeek\BashSoft-FirstWeek\actual.txt", @"C:\Users\Kristofar Hristov\Desktop\BashSoft-FirstWeek\BashSoft-FirstWeek\expected.txt");
        }
    }
}
