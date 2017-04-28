using System;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Example
{
    public class ConsoleLogger : ILogger
    {
        public bool IsEnabled(LogLevel level)
        {
            return true;
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }

    public static class ConsoleLoggerExtensions
    {
        public static void DebugCustom(this ILogger logger, string message)
        {
            logger.Debug("--- " + message + " ---");
            Console.WriteLine();
        }
    }
}