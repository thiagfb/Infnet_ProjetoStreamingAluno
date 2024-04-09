using Streaming.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Streaming.VO
{
    public class AlbumMusicaVO
    {
        public Guid Id { get; set; }

        public String Titulo { get; set; }

        public int AnoLancamento { get; set; }

        public List<Musica> Musica { get; set; } = new List<Musica>();
    }
}
