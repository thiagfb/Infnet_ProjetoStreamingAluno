using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class GeneroRepository : RepositoryBase<Genero>
    {
        public StreamingContext Context { get; set; }

        public GeneroRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
