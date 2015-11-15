using System.IO;
using System.Linq;
using SBD_1.Helpers;

namespace SBD_1.Core
{

    public class Tape
    {
        private readonly string _filePath;
        private int _index;
        private int _size;
        private double _lastValue;
        private bool _isFinished = false;
        public Tape(string filePath)
        {
            _filePath = filePath;
            FileHelper.CreateFile(_filePath);
        }



        public Tape(string filePath, string inputFilePath)
            : this(filePath)
        {
            FileHelper.Copy(inputFilePath, this);
        }

        public double? GetNextValue()
        {
            if (_index + 1 > _size)
            {
                _isFinished = true;
                return null;

            }
            double? value = double.Parse(File.ReadLines(_filePath).ElementAt(_index));
            _index++;
            return value;
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

        public bool IsFinished
        {
            get { return _isFinished; }
        }

        public void Append(double val)
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(val);
            }
            _size++;
            _lastValue = val;
            //Log.WriteInfoMessage(ShowFile());
        }

        public void Append(string line)
        {
            Append(double.Parse(line));
        }

        public string ShowFile()
        {
            int tempIndex = _index;
            _index = 0;
            string line = null;
            double? val;
            while ((val = GetNextValue()) != null)
            {

                line += val + " ";
            }
            _index = tempIndex;
            return line;
        }

        public void Clean()
        {
            FileHelper.CreateFile(_filePath);
            _size = 0;
        }

        public void ZeroIndex()
        {
            _index = 0;
            _isFinished = false;
        }

        public void StepBack()
        {
            _index--;
        }

        public bool IsSorted()
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                double a = -1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    double b = double.Parse(line);
                    if (b < a)
                        return false;
                    a = b;
                }
            }
            return true;
        }
    }
}
