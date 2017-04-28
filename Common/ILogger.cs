using System;

namespace TeamSL.Infrastructure.Tools.Logging
{
    public interface ILogger
    {
        bool IsEnabled(LogLevel level);
        void Log(LogLevel level, Exception exception, string format, params object[] args);
    }
}
