using Streaming.Domain.Conta.Aggregates;

namespace Streaming.Repository.Repository
{
    public class AssinaturaRepository : RepositoryBase<Assinatura>
    {
        public StreamingContext Context { get; set; }

        public AssinaturaRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
