using Streaming.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Repository.Repository
{
    public class ArtistaRepository : RepositoryBase<Artista>
    {
        public StreamingContext Context { get; set; }

        public ArtistaRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }
    }
}
