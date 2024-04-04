using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>
    {
        public StreamingContext Context { get; set; }

        public MusicaRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
