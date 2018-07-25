using TeamSL.Infrastructure.Data;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class DeleteCommandHandler<TRecord> : ICommandHandler<RecordCommand<TRecord>> where TRecord : Record
    {
        private readonly IRepository<TRecord> _recordRepository;

        public DeleteCommandHandler(IRepository<TRecord> recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public void Execute(RecordCommand<TRecord> command)
        {
            _recordRepository.Delete(command.Record);
        }
    }
}