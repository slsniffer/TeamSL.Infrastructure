namespace TeamSL.Infrastructure.Tools.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create(string name);
    }
}