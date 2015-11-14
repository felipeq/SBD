using System.IO;
using SBD_1.Core;

namespace SBD_1.Helpers
{
    static class SortHelper
    {
        internal static void Distribute(Tape src, CyclicList<Tape> dest)
        {
            Log.WriteDistMessage("Dist start");
            string line;
            using (StreamReader reader = new StreamReader(src.FilePath))
                while ((line = reader.ReadLine()) != null)
                {
                    int val = int.Parse(line);
                    if (dest.IsFirstRun() || val >= dest.LastValue)
                    {
                        dest.Add(val);
                        Log.WriteDistMessage("Adding " + val + " to " + dest.Index + ".", 4);
                    }
                    else
                    {
                        dest.ChangeToNextAndAdd(val);
                    }
                    Log.WriteDistMessage("Adding " + val + " to " + dest.Index + ".", 4);
                }
            Log.WriteDistMessage("Dist end");
        }

        public static void Merge(Tape dest, Tape src1, Tape src2)
        {
            Log.WriteMergeMessage("Merge start");
            Log.WriteMergeMessage("0: " + src1.ShowFile(), 5);
            Log.WriteMergeMessage("0: " + src1.ShowFile(), 5);
            Log.WriteMergeMessage("1: " + src2.ShowFile(), 5);

            Log.WriteMergeMessage("Merge end");
        }
    }
}
