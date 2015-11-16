using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SBD_1.Core;

namespace SBD_01_Generator
{
    static class Program
    {
        private static int AMOUNT_MIN = 1;
        private static int AMOUNT_MAX = 99;

        static void Main(string[] args)
        {
            Random random = new Random();
            List<Pentagon> pentagons = new List<Pentagon>();
            for (int j = 0; j < 10; j++)
            {
                int d = (int)(AMOUNT_MIN + Math.Floor(random.NextDouble() * AMOUNT_MAX));
                for (int i = 0; i < d; i++)
                {
                    double[] sides = new double[5];
                    for (int ii = 0; ii < 5; ii++)
                    {
                        sides[ii] = random.NextDouble() * 10;
                    }
                    pentagons.Add(new Pentagon(sides));
                }
                SaveToFile(pentagons, j);
                pentagons.Clear();
            }

            //ReadFromFile(ref pentagons);
            //foreach (Pentagon p in pentagons)
            //{
            //    Console.WriteLine(p.ToString());
            //}
            Console.ReadKey();
        }

        private static void ReadFromFile(ref List<Pentagon> pentagons)
        {
            Console.WriteLine("Saved!\nReading pentagons...");
            pentagons.Clear();
            Stream stream = File.Open("../../../data/pentagons_01.dat", FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            pentagons = (List<Pentagon>)bformatter.Deserialize(stream);
            stream.Close();
        }

        private static void SaveToFile(List<Pentagon> pentagons, int i)
        {
            Stream stream = File.Open("../../../data/pentagons_" + i + ".dat", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            Console.WriteLine("Saving random pentagons...");
            bformatter.Serialize(stream, pentagons);
            stream.Close();
        }
    }
}
