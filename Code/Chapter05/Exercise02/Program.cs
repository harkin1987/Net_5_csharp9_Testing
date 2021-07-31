using System;
using static System.Console;
using Shape;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Rectangle(3f, 4.5f);
            WriteLine($"Rectangle H: {r.height}, W: {r.width}, Area: {r.area}");
            var s = new Square(5f);
            WriteLine($"Square H: {s.height}, W: {s.width}, Area: {s.area}");
            var c = new Circle(2.5f);
            WriteLine($"Circle H: {c.height}, W: {c.width}, Area: {c.area}");
        }
    }
}
