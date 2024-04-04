using Streaming.Domain.Comum.ValueObject;
using Streaming.Domain.Transacao.ValueObject;

namespace Streaming.Domain.Transacao.Aggregates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Merchant Merchant { get; set; }
    }
}
