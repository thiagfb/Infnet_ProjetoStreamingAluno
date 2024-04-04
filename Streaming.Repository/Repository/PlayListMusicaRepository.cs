using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class PlayListMusicaRepository : RepositoryBase<PlayListMusica>
    {
        public StreamingContext Context { get; set; }

        public PlayListMusicaRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
