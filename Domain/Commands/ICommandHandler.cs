namespace TeamSL.Infrastructure.Domain.Commands
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
