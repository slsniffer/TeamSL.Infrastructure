using System;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class DefaultCommander : ICommander
    {
        private readonly ICommandHandlerFactory _factory;

        public ILogger Logger { get; set; }

        public DefaultCommander(ICommandHandlerFactory factory)
        {
            _factory = factory;
            Logger = NullLogger.Instance;
        }

        public void Send<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            ICommandHandler<TCommand> handler = _factory.Create<TCommand>();

            if (handler == null)
                throw new CommandHandlerNotFoundException(typeof(TCommand));

            handler.Execute(command);
        }
    }
}
