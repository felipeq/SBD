using System.IO;

namespace SBD_1.Helpers
{
    public static class FileHelper
    {
        public static void Copy(string src, string dest)
        {
            using (StreamReader reader = new StreamReader(src))
            {
                using (StreamWriter writer = new StreamWriter(dest))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public static void Write(string src, double value)
        {
            using (FileStream fs = new FileStream(src, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(value);
            }
        }
    }
}
