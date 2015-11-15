using System;
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
            Program.Main(new[] { "../../../data/in_02.txt", "TEST" });

        }
    }
}
