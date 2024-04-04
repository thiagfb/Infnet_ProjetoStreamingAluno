using Streaming.Domain.Conta.Aggregates;

namespace Streaming.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {        public StreamingContext Context { get; set; }

        public UsuarioRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
