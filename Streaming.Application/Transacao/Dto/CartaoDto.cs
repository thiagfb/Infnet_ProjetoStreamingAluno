using Streaming.Domain.Comum.ValueObject;
using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Application.Transacao.Dto
{
    public class CartaoDto
    {
        public Guid Id { get; set; }

        public Boolean Ativo { get; set; }

        public Monetario Limite { get; set; }

        public String Numero { get; set; }

        public int CVV { get; set; }

        public Bandeira Bandeira { get; set; }

        public List<Domain.Transacao.Aggregates.Transacao> LstTransacao { get; set; } = new List<Domain.Transacao.Aggregates.Transacao>();
    }
}
