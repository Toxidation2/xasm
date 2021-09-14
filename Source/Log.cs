using System;

namespace xasm 
{
    internal class Log
    {
        public static void Send(string Text, Severity LogSeverity = Severity.Info)
        {
            Console.WriteLine($"xasm: {LogSeverity.ToString().ToLower()}: {Text}");
        }  
    }

    internal enum Severity
    {
        Fatal, Error, Warn, Info, Debug
    }
}