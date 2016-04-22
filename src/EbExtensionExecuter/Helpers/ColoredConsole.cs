using System;
using static System.Console;

namespace EbExtensionExecuter.Helpers
{
    public static class ColoredConsole
    {
        public static void WriteLine(string str, ConsoleColor color, params object[] parameters)
        {
            ForegroundColor = color;
            WriteLine(str, parameters);
            ResetColor();
        }

        public static void WriteLine(string str, params object[] parameters)
            => Console.WriteLine(str, parameters);
    }
}
