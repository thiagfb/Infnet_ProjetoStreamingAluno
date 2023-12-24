using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Domain.Transacao.ValueObject;

namespace Streaming.Tests.Domain.Transacao
{
    public class CartaoTests
    {
        [Fact]
        public void CriarTransacaoComSucesso()
        {
            Bandeira bandeira = new Bandeira();
            bandeira = bandeira.AdicionarBandeira("Visa");

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
                Bandeira = bandeira,
                CVV = 888
            };

            var merchant = new Merchant()
            {
                Nome = "Open"
            };

            cartao.CriarTransacao(19M, merchant, "Open Transacao");
            Assert.True(cartao.LstTransacao.Count > 0);
            Assert.True(cartao.Limite == 981M);
        }

        [Fact]
        public void CriarTransacaoComErroCVV()
        {
            Bandeira bandeira = new Bandeira();
            bandeira = bandeira.AdicionarBandeira("Visa");

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
                Bandeira = bandeira
            };

            var merchant = new Merchant()
            {
                Nome = "Open"
            };

            Usuario usuario = new Usuario();

            Assert.Throws<Exception>(() =>
            {
                cartao.CriarTransacao(19M, merchant, "Open Transacao");
            });
        }

        [Fact]
        public void CriarTransacaoComErroCartaoInativo()
        {
            Bandeira bandeira = new Bandeira();
            bandeira = bandeira.AdicionarBandeira("Visa");

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1000M,
                Numero = "6465465466",
                CVV = 7
            };

            var merchant = new Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<Exception>(() =>
            {
                cartao.CriarTransacao(19M, merchant, "Open Transacao");
            });
        }
    }
}
