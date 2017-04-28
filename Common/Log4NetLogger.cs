using System;
using log4net;

namespace TeamSL.Infrastructure.Tools.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _log;

        public Log4NetLogger(ILog log)
        {
            _log = log;
        }

        public bool IsEnabled(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return _log.IsDebugEnabled;
                case LogLevel.Information:
                    return _log.IsInfoEnabled;
                case LogLevel.Warning:
                    return _log.IsWarnEnabled;
                case LogLevel.Error:
                    return _log.IsErrorEnabled;
                case LogLevel.Fatal:
                    return _log.IsFatalEnabled;
                default:
                    throw new ArgumentOutOfRangeException("level");
            }
        }

        public void Log(LogLevel level, Exception exception, string format, params object[] args)
        {
            string message = args != null ? string.Format(format, args) : format;

            switch (level)
            {
                case LogLevel.Debug:
                    _log.Debug(message, exception);
                    break;
                case LogLevel.Information:
                    _log.Info(message, exception);
                    break;
                case LogLevel.Warning:
                    _log.Warn(message, exception);
                    break;
                case LogLevel.Error:
                    _log.Error(message, exception);
                    break;
                case LogLevel.Fatal:
                    _log.Fatal(message, exception);
                    break;
            }
        }
    }
}