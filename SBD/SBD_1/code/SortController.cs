using SBD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBD_1.code
{
    static class SortController
    {
        internal static void Distribute(Tape src, CyclicList<Tape> dest)
        {
            using (StreamReader reader = new StreamReader(src.FilePath,))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int val = int.Parse(line);
                    if (val <= dest.LastValue)
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
