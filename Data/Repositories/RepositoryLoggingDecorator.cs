using TeamSL.Infrastructure.Tools.Logging;

namespace TeamSL.Infrastructure.Data
{
    public class RepositoryLoggingDecorator<TRecord> : IRepository<TRecord> where TRecord : Record
    {
        private readonly IRepository<TRecord> _decorated;

        public ILogger Logger { get; set; }

        public RepositoryLoggingDecorator(IRepository<TRecord> decorated)
        {
            _decorated = decorated;
            Logger = NullLogger.Instance;
        }

        void IRepository<TRecord>.Create(TRecord record)
        {
            Logger.Debug("Create new {0}", typeof(TRecord).Name);

            _decorated.Create(record);
        }

        void IRepository<TRecord>.CreateOrUpdate(TRecord record)
        {
            Logger.Debug("Create new or update {0}", typeof(TRecord).Name);

            _decorated.CreateOrUpdate(record);
        }

        void IRepository<TRecord>.Delete(TRecord record)
        {
            Logger.Debug("Delete {0}.Id: {1}", typeof(TRecord).Name, record.Id);

            _decorated.Delete(record);
        }

        void IRepository<TRecord>.Update(TRecord record)
        {
            Logger.Debug("Save {0}.Id: {1}", typeof(TRecord).Name, record.Id);

            _decorated.Update(record);
        }
    }
}