using System;

namespace SBD_1.Helpers
{
    public static class Log
    {
        static ConsoleColor InfoMsgBg = ConsoleColor.Black;
        static ConsoleColor InfoMsgFg = ConsoleColor.Green;

        static ConsoleColor DistMsgBg = ConsoleColor.Black;
        static ConsoleColor DistMsgFg = ConsoleColor.Red;

        static ConsoleColor MergeMsgBg = ConsoleColor.Black;
        static ConsoleColor MergeMsgFg = ConsoleColor.Yellow;

        public static void WriteInfoMessage(string msg, int padding = 0)
        {
            Console.BackgroundColor = InfoMsgBg;
            Console.ForegroundColor = InfoMsgFg;
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static void WriteDistMessage(string msg, int padding = 5)
        {
            Console.BackgroundColor = DistMsgBg;
            Console.ForegroundColor = DistMsgFg;
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(msg);

            Console.ResetColor();
        }
        public static void WriteMergeMessage(string msg, int padding = 5)
        {
            Console.BackgroundColor = MergeMsgBg;
            Console.ForegroundColor = MergeMsgFg;
            Console.SetCursorPosition(padding, Console.CursorTop);
            Console.WriteLine(msg);

            Console.ResetColor();
        }
    }
}
