using TeamSL.Infrastructure.Data;

namespace TeamSL.Infrastructure.Domain.Commands
{
    public class UpdateCommandHandler<TRecord> : ICommandHandler<RecordCommand<TRecord>> where TRecord : Record
    {
        private readonly IRepository<TRecord> _recordRepository;

        public UpdateCommandHandler(IRepository<TRecord> recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public void Execute(RecordCommand<TRecord> command)
        {
            _recordRepository.CreateOrUpdate(command.Record);
        }
    }
}