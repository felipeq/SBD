using System;
using System.Collections.Generic;
using SBD_1.Core;

namespace SBD_01_Generator
{
    static class Program
    {
        public static int AMOUNT = 5;
        static void Main(string[] args)
        {
            Pentagon pentagon = new Pentagon(new[] { 1.0, 1.0, 1.0, 1.0, 1.0 });
            Random random = new Random();
            List<Pentagon> pentagons = new List<Pentagon>();
            for (int i = 0; i < AMOUNT; i++)
            {

                for (int ii = 0; ii < 5; ii++)
                {

                }
            }
        }


    }
}
