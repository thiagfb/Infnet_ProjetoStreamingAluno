using Streaming.Domain.Comum.ValueObject;
using Streaming.Domain.Transacao.ValueObject;

namespace Streaming.Domain.Transacao.Aggregates
{
    public class Cartao
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO_MERCHANT = 1;

        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Monetario Limite { get; set; }
        public String Numero { get; set; }
        public int CVV { get; set; }
        public Bandeira Bandeira { get; set; }
        public List<Transacao> LstTransacao { get; set; } = new List<Transacao>();

        public Cartao AdicionarCartao(Monetario limite, String numero, int CVV, Bandeira bandeira, Boolean ativo = true)
        {
            this.Id = Guid.NewGuid();
            
            this.Limite = limite;

            this.Numero = numero;

            this.CVV = CVV;

            this.Bandeira = bandeira;

            this.Ativo = ativo;

            return this;
        }

        public void CriarTransacao(Monetario valor, Merchant merchant, String Descricao = null)
        {
            this.CartaoAtivo();
            this.ValidarCVV();

            Transacao transacao = new Transacao();
            transacao.Id = Guid.NewGuid();
            transacao.DataTransacao = DateTime.Now;
            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.Merchant = merchant;

            this.VerificarLimite(transacao);

            //Verifica regras antifraude
            this.ValidarTransacao(transacao);

            //Reduzir o limite
            this.Limite = this.Limite - transacao.Valor;

            this.LstTransacao.Add(transacao);
        }

        private void CartaoAtivo()
        {
            if (this.Ativo == false)
                throw new Exception("Cartão inativo");
        }

        private void ValidarCVV()
        {
            if (this.CVV == 0)
                throw new Exception("CVV não informado");
        }

        private void VerificarLimite(Transacao transacao)
        {
            if (this.Limite < transacao.Valor)
                throw new Exception("Cartão não possui limite para esta transação");
        }

        private void ValidarTransacao(Transacao transacao)
        {
            var ultimasTransacoes = this.LstTransacao.Where(x =>
                                                          x.DataTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            if (ultimasTransacoes?.Count() >= 3)
                throw new Exception("Cartão utilizado muitas vezes em um período curto");

            var transacaoRepetidaPorMerchant = ultimasTransacoes?
                                                .Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper()
                                                       && x.Valor == transacao.Valor)
                                                .Count() == REPETICAO_TRANSACAO_MERCHANT;

            if (transacaoRepetidaPorMerchant)
                throw new Exception("Transação duplicada para o mesmo cartão e o mesmo comerciante");

        }

    }
}
