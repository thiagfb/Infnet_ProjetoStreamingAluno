using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class AlbumRepository : RepositoryBase<Album>
    {
        public StreamingContext Context { get; set; }

        public AlbumRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
