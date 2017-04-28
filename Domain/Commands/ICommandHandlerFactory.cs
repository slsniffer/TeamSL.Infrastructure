namespace TeamSL.Infrastructure.Domain.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Create<TCommand>()
            where TCommand : ICommand;
    }
}
