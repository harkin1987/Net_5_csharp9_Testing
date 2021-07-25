using System;
using static System.Console;
using static System.Convert;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("var y = 2 + ++x;");
            var x = 3; var y = 2 + ++x;
            WriteLine($"x is: {x} | y is: {y}");
            WriteLine("x = 3 << 2;y = 10 >> 1;");
            x = 3 << 2;y = 10 >> 1;
            WriteLine($"x is: {x} | y is: {y}");
            WriteLine("x = 10 & 8;y = 10 | 7;");
            x = 10 & 8;y = 10 | 7;
            WriteLine($"x is: {x} | y is: {y}");
        }
    }
}
