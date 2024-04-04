using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Dto
{
    public class PlayListMusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Publica { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual List<Musica> LstMusica { get; set; } = new List<Musica>();
    }
}
