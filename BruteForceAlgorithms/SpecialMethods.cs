using System;
using System.Collections.Generic;
using System.Text;

namespace BruteForceAlgorithms
{
    public static class SpecialMethods
    {
        public static void ColorPrint(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static bool GetNextP(char[] P)
        {
            int i, j, n = P.Length;
            i = n - 1;
            while (i > 0 && P[i] <= P[i - 1])
                i--;
            if (i == 0)
            {
                return false;
            }
            j = n - 1;
            while (P[j] <= P[i - 1])
                j--;
            Swap(ref P[i - 1], ref P[j]);
            for (j = 0; j < (n - i) / 2; j++)
            {
                Swap(ref P[i + j], ref P[n - 1 - j]);
            }
            return true;
        }

        private static void Swap(ref char a, ref char b)
        {
            char t;
            t = a; a = b; b = t;
        }
    }
}
