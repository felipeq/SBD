using SBD_1.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBD
{
    class Program
    {

        static void Main(string[] args)
        {
            Tape a = new Tape("a.txt", true);
            Tape b = new Tape("b.txt", true);
            Tape c = new Tape("../../../data/in_01.txt", false);
            Console.WriteLine("Hello world!");
            Console.WriteLine("Distribution");
            SortController.Distribute(c, new CyclicList<Tape>() { a, b });
        }
    }
}
