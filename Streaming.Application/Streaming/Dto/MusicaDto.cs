using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Dto
{
    public class MusicaDto
    {
        public Guid Id { get; set; }

        public String Titulo { get; set; }

        public Guid GeneroId { get; set; }

        public Guid Compositorid { get; set; }

        public String Letra { get; set; }

        public DateTime? DataComposicao { get; set; }
    }
}
