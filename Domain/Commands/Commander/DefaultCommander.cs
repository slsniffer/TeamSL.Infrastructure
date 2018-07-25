using System;
using TeamSL.Infrastructure.Data;
using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class DefaultCommander : ICommander
    {
        private readonly ICommandHandlerFactory _factory;
        private readonly IRepositoryFactory _repositoryFactory;

        public ILogger Logger { get; set; }

        public DefaultCommander(ICommandHandlerFactory factory, IRepositoryFactory repositoryFactory)
        {
            _factory = factory;
            _repositoryFactory = repositoryFactory;
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

        public void Update<TRecord>(TRecord record) where TRecord : Record
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var handler = new UpdateCommandHandler<TRecord>(_repositoryFactory.Write<TRecord>());

            handler.Execute(new RecordCommand<TRecord>(record));
        }

        public void Delete<TRecord>(TRecord record) where TRecord : Record
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            var handler = new DeleteCommandHandler<TRecord>(_repositoryFactory.Write<TRecord>());

            handler.Execute(new RecordCommand<TRecord>(record));
        }
    }
}
