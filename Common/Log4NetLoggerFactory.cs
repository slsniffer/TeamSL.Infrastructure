using log4net;

namespace TeamSL.Infrastructure.Tools.Logging
{
    public class Log4NetLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
            return new Log4NetLogger(LogManager.GetLogger(name));
        }
    }
}