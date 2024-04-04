using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Domain.Conta.Aggregates
{
    public class Assinatura
    {
        public Guid Id { get; set; }

        public virtual Plano Plano { get; set; }

        public Boolean Ativo { get; set; }

        public DateTime DataAtivacao { get; set; }

        public DateTime DataAtivacaoFim { get; set; }
    }
}
