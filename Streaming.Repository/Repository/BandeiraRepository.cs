using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Repository.Repository
{
    public class BandeiraRepository : RepositoryBase<Bandeira>
    {
        public StreamingContext Context { get; set; }

        public BandeiraRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }

    }
}
