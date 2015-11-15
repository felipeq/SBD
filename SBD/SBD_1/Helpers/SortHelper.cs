using System;
using System.IO;
using System.Security.AccessControl;
using SBD_1.Core;

namespace SBD_1.Helpers
{
    static class SortHelper
    {
        internal static void Distribute(Tape src, CyclicList<Tape> tapes)
        {
            //Log.WriteDistMessage("Dist start");
            tapes.Clean();
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
                        //Log.WriteInfoMessage("NIEPOSORTOWANE!" + val);
                    }
                    //Log.WriteDistMessage("Adding " + val + " to " + tapes.Index + ".", 4);
                }
            Log.WriteDistMessage("A: " + tapes[0].ShowFile());
            Log.WriteDistMessage("B: " + tapes[1].ShowFile());
            //Log.WriteDistMessage("Dist end");
        }

        public static void Merge(Tape dest, CyclicList<Tape> tapes)
        {
            //Log.WriteMergeMessage("Merge start");
            //Log.WriteMergeMessage("A: " + tapes[0].ShowFile(), 5);
            //Log.WriteMergeMessage("B: " + tapes[1].ShowFile(), 5);
            dest.Clean();
            tapes.Prepare();

            double a1 = (double)tapes.Current.GetNextValue();

            double b1 = -1;

            while (!tapes.Current.IsFinished)
            {
                double? nextValue = tapes.Next.GetNextValue();
                double b2;
                if (nextValue != null)
                    b2 = (double)nextValue;
                else
                    break; // przepisz resztę taśmy
                if (b2 >= b1) // czy ciągle na tym samym run-ie
                {
                    if (b2 <= a1)
                    {
                        b1 = b2;
                        dest.Append(b1);
                    }
                    else
                    {
                        dest.Append(a1);
                        tapes.MoveNext();
                        b1 = a1;
                        a1 = b2;
                    }
                }
                else // przepisz resztę run-a
                {
                    b1 = b2;
                    double a2 = a1;
                    var value = tapes.Current.GetNextValue();
                    if (value != null) a1 = (double)value;
                    while (a1 >= a2)
                    {
                        dest.Append(a2);
                        a2 = a1;
                        double? d = tapes.Current.GetNextValue();
                        if (d != null) a1 = (double)d;
                        else
                            break;
                    }
                    dest.Append(a2);
                    tapes.Next.StepBack();
                }
            }
            double? v;
            dest.Append(a1);
            while ((v = tapes.Current.GetNextValue()) != null)
            {
                dest.Append((double)v);
            }
            //Log.WriteMergeMessage("Result:", 5);
            Log.WriteMergeMessage("C: " + dest.ShowFile());
            //Log.WriteMergeMessage("Merge end");
        }

        internal static bool IsSorted(Tape tape)
        {
            return tape.IsSorted();
        }
    }
}
