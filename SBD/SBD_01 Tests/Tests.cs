using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SBD_1.Core;

namespace SBD_01_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void in_01()
        {
            int input = 1;
            Assert.IsTrue(Check(input));
        }
        [TestMethod]
        public void in_02()
        {
            int input = 2;
            Assert.IsTrue(Check(input));
        }
        private static bool Check(int input)
        {

            Program.Main(new[] { "../../../data/in_0" + input + ".txt", "TEST" });
            using (StreamReader readerA = new StreamReader("c.txt"))
            using (StreamReader readerB = new StreamReader("../../../data/out_0" + input + ".txt"))
            {
                string lineA = readerA.ReadLine();
                string lineB = readerB.ReadLine();
                Console.WriteLine("/in_0" + input + ".txt");
                while (lineA != null)
                {
                    Console.WriteLine(lineA + " vs " + lineB);
                    if (!lineA.Equals(lineB))
                        return false;
                    lineA = readerA.ReadLine();
                    lineB = readerB.ReadLine();
                }
            }
            return true;
        }
    }
}
