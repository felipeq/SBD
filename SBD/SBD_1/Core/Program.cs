using System;
using SBD_1.Helpers;

namespace SBD_1.Core
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Tape a = new Tape("a.txt");
            Tape b = new Tape("b.txt");
            Tape c = new Tape("c.txt", "../../../data/in_01.txt");

            Log.WriteInfoMessage("Natural sort\n");
            SortHelper.Distribute(c, new CyclicList<Tape>() { a, b });
            SortHelper.Merge(c, a, b);

            Log.WriteInfoMessage("End of execution\n");
            Console.ReadKey();
        }
    }
}
