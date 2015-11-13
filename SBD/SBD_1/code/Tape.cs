using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBD
{

    public class Tape
    {
        private string _filePath;
        private int index = 0;
        private double _lastValue;
        public Tape(string filePath, bool doOverride)
        {
            _filePath = filePath;
            if (doOverride && File.Exists(_filePath))
                File.Delete(_filePath);
            File.Create(_filePath);
        }

        internal double getNextValue()
        {
            return double.Parse(File.ReadLines(_filePath).ElementAt(++index));
        }

        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }
        public double LastValue
        {
            get
            {
                return _lastValue;

            }
        }
        public void Add(double val)
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(val);
            }
            _lastValue = val;
        }
    }
}
