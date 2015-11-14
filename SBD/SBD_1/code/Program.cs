using System;
using SBD_1.Helpers;

namespace SBD_1.code
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Tape a = new Tape("a.txt");
            Tape b = new Tape("b.txt");
            Tape c = new Tape("c.txt", "../../../data/in_01.txt");

            Console.WriteLine("Hello world!");
            Console.WriteLine("Distribution");
            SortHelper.Distribute(c, new CyclicList<Tape>() { a, b });
        }
    }
}
