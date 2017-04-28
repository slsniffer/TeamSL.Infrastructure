using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class CommandHandlerLoggingDecorator<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> _decorated;

        public ILogger Logger { get; set; }

        public CommandHandlerLoggingDecorator(ICommandHandler<TCommand> decorated)
        {
            _decorated = decorated;
            Logger = NullLogger.Instance;
        }

        public void Execute(TCommand command)
        {
            try
            {
                Logger.Information("Command [{0}] start.", typeof(TCommand).Name);
                _decorated.Execute(command);
            }
            finally
            {
                Logger.Information("Command [{0}] done.", typeof(TCommand).Name);
            }
        }
    }

}
