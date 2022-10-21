using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_in_console
{
    public static class Input
    {
        static readonly Random random = new Random();
        static bool E { get; set; }
        public static void SetEesy()
        {
            if (E)
                E = false;
            else
                E = true;
        }
        public static bool GetLine(string[] Line)
        {
            bool Re = false;
            string In = Console.ReadLine();
            for (int i = 0; i < Line.Length; i++)
            {
                if (In == Line[i])
                    Re = true;
            }
            return Re;
        }
        public static bool Chance(int a, int min, int max)
        {
            if (random.Next(min, max) < a)
                return true;
            else
                return false;
        }
        public static int ChanceOut(int min, int max)
        {
            return random.Next(min, max);
        }
        public static int Range(int min, int max, int x)
        {
            if (random.Next(min, max) == x)
                return 1;
            else
                return 0;
        }
    }
}
