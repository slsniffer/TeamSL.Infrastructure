using TeamSL.Infrastructure.Data;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public interface ICommander
    {
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
        void Update<TRecord>(TRecord record) where TRecord : Record;
        void Delete<TRecord>(TRecord record) where TRecord : Record;
    }
}
