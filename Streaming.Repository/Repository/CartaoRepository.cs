using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Repository.Repository
{
    public class CartaoRepository : RepositoryBase<Cartao>
    {
        public StreamingContext Context { get; set; }

        public CartaoRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
