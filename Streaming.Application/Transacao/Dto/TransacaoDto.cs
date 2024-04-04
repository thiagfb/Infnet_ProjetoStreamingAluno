using Streaming.Domain.Comum.ValueObject;
using Streaming.Domain.Transacao.ValueObject;

namespace Streaming.Application.Transacao.Dto
{
    public class TransacaoDto
    {
        public Guid Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Merchant Merchant { get; set; }
    }
}
