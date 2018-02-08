using Autofac;
using TeamSL.Infrastructure.Domain.Commands;

namespace TeamSL.Infrastructure.Domain
{
    public class AutofacCommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IComponentContext _resolver;

        public AutofacCommandHandlerFactory(IComponentContext resolver)
        {
            _resolver = resolver;
        }

        public ICommandHandler<TCommand> Create<TCommand>() where TCommand : ICommand
        {
            return _resolver.Resolve<ICommandHandler<TCommand>>();
        }
    }
}
