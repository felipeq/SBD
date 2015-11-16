using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace SBD_1.Core
{
    [Serializable]
    public class Pentagon : ISerializable
    {
        private double[] _sides;

        public Pentagon(double[] sides)
        {
            _sides = sides;
        }

        public Pentagon(SerializationInfo info, StreamingContext context)
        {
            _sides = (double[])info.GetValue("_sides", typeof(double[]));
        }

        private double SumOfSides
        {
            get { return _sides.Sum(d => d); }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_sides", _sides);
        }

        public override string ToString()
        {
            string res = _sides.Aggregate<double, string>(null, (current, d) => current + (d + "\n"));
            return res + "SUMA: " + SumOfSides;
        }
    }
}
