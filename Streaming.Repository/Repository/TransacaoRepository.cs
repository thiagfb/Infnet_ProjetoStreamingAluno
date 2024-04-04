using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Repository.Repository
{
    public class TransacaoRepository : RepositoryBase<Transacao>
    {
        public StreamingContext Context { get; set; }

        public TransacaoRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
