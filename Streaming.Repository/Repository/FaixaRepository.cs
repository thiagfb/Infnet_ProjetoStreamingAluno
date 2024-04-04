using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class FaixaRepository : RepositoryBase<Faixa>
    {
        public StreamingContext Context { get; set; }

        public FaixaRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
