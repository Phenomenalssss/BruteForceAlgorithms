using System;
using System.Collections.Generic;
using System.Text;

namespace BruteForceAlgorithms
{
    public static class ColorPrint
    {
        public static void Run(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
