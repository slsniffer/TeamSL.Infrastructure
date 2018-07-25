using TeamSL.Infrastructure.Data;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class RecordCommand<TRecord> : ICommand
        where TRecord : Record
    {
        public TRecord Record { get; }

        public RecordCommand(TRecord record)
        {
            Record = record;
        }
    }
}