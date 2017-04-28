using System;

namespace TeamSL.Infrastructure.Tools.Logging
{
    public class NullLogger : ILogger
    {
        private static NullLogger _instance;
        private static readonly object _lock = new object();
        private NullLogger()
        {
        }

        public bool IsEnabled(LogLevel level)
        {
            return false;
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
        }

        public static ILogger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new NullLogger();
                    return _instance;
                }
            }
        }
    }
}