using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Streaming.ValueObject;

namespace Streaming.Application.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }

        public String Titulo { get; set; }

        public Guid ArtistaId { get; set; }

        public int AnoLancamento { get; set; }

        public Duracao? Duracao { get; set; }

        public List<Faixa> LstFaixa { get; set; } = new List<Faixa>();
    }
}
