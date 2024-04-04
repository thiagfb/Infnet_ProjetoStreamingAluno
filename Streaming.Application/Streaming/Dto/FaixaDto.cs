using Streaming.Domain.Streaming.ValueObject;

namespace Streaming.Application.Streaming.Dto
{
    public class FaixaDto
    {
        public Guid Id { get; set; }

        public Guid MusicaId { get; set; }

        public int Ordem { get; set; }

        public Duracao Duracao { get; set; }
    }
}
