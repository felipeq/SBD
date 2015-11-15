using System;
using System.Linq;
using System.Runtime.Serialization;

namespace SBD_1.Core
{
    [Serializable]
    public class Pentagon : ISerializable
    {
        private double[] _sides;
        private double _sumOfSides;
        public Pentagon(double[] sides)
        {
            _sides = sides;
            _sumOfSides = _sides.Sum(d => d);
        }

        public Pentagon(SerializationInfo info, StreamingContext context)
        {
            _sides = (double[])info.GetValue("_sides", typeof(double[]));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_sides", _sides);
        }
    }
}
