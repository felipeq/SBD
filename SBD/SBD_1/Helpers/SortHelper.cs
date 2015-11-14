using System;
using System.IO;
using SBD_1.Core;

namespace SBD_1.Helpers
{
    static class SortHelper
    {
        internal static void Distribute(Tape src, CyclicList<Tape> tapes)
        {
            Log.WriteDistMessage("Dist start");
            string line;
            using (StreamReader reader = new StreamReader(src.FilePath))
                while ((line = reader.ReadLine()) != null)
                {
                    int val = int.Parse(line);
                    if (tapes.IsFirstRun() || val >= tapes.LastValue)
                    {
                        tapes.Add(val);
                        //Log.WriteDistMessage("Adding " + val + " to " + tapes.Index + ".", 4);
                    }
                    else
                    {
                        tapes.ChangeToNextAndAdd(val);
                    }
                    Log.WriteDistMessage("Adding " + val + " to " + tapes.Index + ".", 4);
                }
            Log.WriteDistMessage("Dist end");
        }

        public static void Merge(Tape dest, CyclicList<Tape> tapes)
        {
            Log.WriteMergeMessage("Merge start");
            Log.WriteMergeMessage("0: " + tapes[0].ShowFile(), 5);
            Log.WriteMergeMessage("1: " + tapes[1].ShowFile(), 5);
            Log.WriteMergeMessage("---", 5);
            Log.WriteMergeMessage("2: " + dest.ShowFile(), 5);
            Log.WriteMergeMessage("---", 5);
            dest.Clean();
            tapes.Prepare();
            double a1, b1 = -1, b2;
            while ((a1 = (double)tapes.Current.GetNextValue()) != null)
            {
                b2 = (double)tapes.Next.GetNextValue();
                if (b2 >= b1)
                {
                    if (b2 <= a1)
                    {
                        b1 = b2;
                        dest.Append(b1);
                        continue;
                    }
                    else
                    {
                        tapes.MoveNext();
                    }
                }
                else
                {
                    throw new NotImplementedException("przepisz resztę z taśmy");
                }
            }
            Log.WriteMergeMessage("Merge end");
        }
    }
}
