using System.IO;
using SBD_1.Core;

namespace SBD_1.Helpers
{
    public static class FileHelper
    {
        public static void Copy(string src, Tape dest)
        {
            using (StreamReader reader = new StreamReader(src))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    dest.Append(line);
                }
            }
        }
        public static void CreateFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
            File.Create(filePath).Close();
        }
    }
}
