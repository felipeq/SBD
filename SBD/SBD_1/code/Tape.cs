using System.IO;
using System.Linq;
using SBD_1.Helpers;

namespace SBD_1.code
{

    public class Tape
    {
        private readonly string _filePath;
        private int _index;
        private double _lastValue;
        public Tape(string filePath)
        {
            _filePath = filePath;
            if (File.Exists(_filePath))
                File.Delete(_filePath);
            File.Create(_filePath).Close();
        }

        public Tape(string filePath, string inputFilePath)
            : this(filePath)
        {
            FileHelper.Copy(inputFilePath, filePath);
        }

        internal double GetNextValue()
        {
            return double.Parse(File.ReadLines(_filePath).ElementAt(++_index));
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
            FileHelper.Write(_filePath, val);
            _lastValue = val;
        }

        public Tape CopyFrom(string dataInTxt)
        {

            return this;
        }
    }
}
