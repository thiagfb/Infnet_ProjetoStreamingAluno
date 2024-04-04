using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public StreamingContext Context { get; set; }

        public PlanoRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
