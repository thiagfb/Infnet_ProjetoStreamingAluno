using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class CompositorRepository : RepositoryBase<Compositor>
    {
        public StreamingContext Context { get; set; }

        public CompositorRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
