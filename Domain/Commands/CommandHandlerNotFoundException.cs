using System;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException(Type type)
            : base(string.Format("Command handler not found for command: {0}", type))
        {
        }
    }
}
