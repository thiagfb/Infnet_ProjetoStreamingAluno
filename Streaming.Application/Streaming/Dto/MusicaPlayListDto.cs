using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Application.Streaming.Dto
{
    public class MusicaPlayListDto
    {
        public virtual Guid UsuarioId { get; set; }

        public virtual Guid MusicaId { get; set; }
    }
}
