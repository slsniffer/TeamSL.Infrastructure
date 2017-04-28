namespace TeamSL.Infrastructure.Domain.Commands
{
    public interface ICommander
    {
        void Send<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}
