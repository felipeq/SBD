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
            var input = args.Length == 0 ? "../../../data/in_01.txt" : args[0];
            Tape c = new Tape("c.txt", input);

            Log.WriteInfoMessage("Natural sort");
            CyclicList<Tape> tapes = new CyclicList<Tape>() { a, b };

            while (!SortHelper.IsSorted(c))
            {

                SortHelper.Distribute(c, tapes);
                SortHelper.Merge(c, tapes);
            }
            Log.WriteInfoMessage("End of execution");
            if (!(args.Length == 2 && args[1].Equals("TEST")))
                Console.ReadKey();
        }
    }
}
