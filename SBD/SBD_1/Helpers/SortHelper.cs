using System.IO;
using SBD_1.code;

namespace SBD_1.Helpers
{
    static class SortHelper
    {
        internal static void Distribute(Tape src, CyclicList<Tape> dest)
        {
            using (StreamReader reader = new StreamReader(src.FilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int val = int.Parse(line);
                    if (dest.IsFirstRun() || val >= dest.LastValue)
                    {
                        dest.Add(val);
                    }
                    else
                    {
                        dest.ChangeToNextAndAdd(val);
                    }
                }
            }
        }
    }
}
