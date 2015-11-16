using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SBD_1.Core;

namespace SBD_01_Generator
{
    static class Program
    {
        private static int AMOUNT = 5;
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Pentagon> pentagons = new List<Pentagon>();
            for (int i = 0; i < AMOUNT; i++)
            {
                double[] sides = new double[5];
                for (int ii = 0; ii < 5; ii++)
                {
                    sides[ii] = random.NextDouble() * 10;
                }
                pentagons.Add(new Pentagon(sides));
            }
            SaveToFile(pentagons);
            ReadFromFile(ref pentagons);
            foreach (Pentagon p in pentagons)
            {
                Console.WriteLine(p.ToString());
            }
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

        private static void SaveToFile(List<Pentagon> pentagons)
        {
            Stream stream = File.Open("../../../data/pentagons_01.dat", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            Console.WriteLine("Saving random pentagons...");
            bformatter.Serialize(stream, pentagons);
            stream.Close();
        }
    }
}
