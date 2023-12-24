using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Domain.Transacao.ValueObject;

namespace Streaming.Tests.Domain.Conta
{
    public class UsuarioTests
    {
        [Fact]
        public void CriarUsuarioComSucesso()
        {
            Bandeira bandeira = new Bandeira();
            bandeira = bandeira.AdicionarBandeira("Visa");

            Cartao cartao = new Cartao();
            cartao = cartao.AdicionarCartao(1000M, "123456", 888, bandeira);

            var merchant = new Merchant()
            {
                Nome = "Open"
            };

            Plano plano = new Plano();
            plano = plano.AdicionarPlano("Single", "Single People", 9.90M, 1);


            string nome = "Joaquim";
            string email = "Joaquim@xpto.com";
            string senha = "123456";
            string dataNascimento = "12/04/1982";
            string telefone = "987654321";

            Usuario usuario = new Usuario();
            usuario.CriarConta(nome, email, senha, Convert.ToDateTime(dataNascimento), telefone, plano, cartao);

            //Assert
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Nome);
            Assert.NotNull(usuario.Telefone);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.Telefone == telefone);
            Assert.True(usuario.Senha != senha);

            Assert.True(usuario.LstAssinatura.Count > 0);
            Assert.Same(usuario.LstAssinatura[0].Plano, plano);

            Assert.True(usuario.LstCartao.Count > 0);
            Assert.Same(usuario.LstCartao[0], cartao);
        }

        [Fact]
        public void CriarUsuarioComErroCartaoSemLimite()
        {
            Bandeira bandeira = new Bandeira();
            bandeira = bandeira.AdicionarBandeira("Visa");

            Cartao cartao = new Cartao();
            cartao = cartao.AdicionarCartao(10M, "123456", 888, bandeira);

            var merchant = new Merchant()
            {
                Nome = "Open"
            };

            Plano plano = new Plano();
            plano = plano.AdicionarPlano("Single", "Single People", 19.90M, 1);


            string nome = "Joaquim";
            string email = "Joaquim@xpto.com";
            string senha = "123456";
            string dataNascimento = "12/04/1982";
            string telefone = "987654321";

            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new Usuario();
                usuario.CriarConta(nome, email, senha, Convert.ToDateTime(dataNascimento), telefone, plano, cartao);
            });
        }

        [Fact]
        public void CriarUsuarioComSucessoEPlayList()
        {
            Bandeira bandeira = new Bandeira();
            bandeira = bandeira.AdicionarBandeira("Visa");

            Cartao cartao = new Cartao();
            cartao = cartao.AdicionarCartao(1000M, "123456", 888, bandeira);

            var merchant = new Merchant()
            {
                Nome = "Open"
            };

            Plano plano = new Plano();
            plano = plano.AdicionarPlano("Single", "Single People", 9.90M, 1);


            string nome = "Joaquim";
            string email = "Joaquim@xpto.com";
            string senha = "123456";
            string dataNascimento = "12/04/1982";
            string telefone = "987654321";

            Usuario usuario = new Usuario();
            usuario.CriarConta(nome, email, senha, Convert.ToDateTime(dataNascimento), telefone, plano, cartao);

            Compositor compositor = new Compositor();
            compositor = compositor.AdicionarCompositor("Anderson Freire");

            Genero genero = new Genero();
            genero = genero.AdicionarGenero("Gospel");

            Musica musica = new Musica();
            musica = musica.AdicionarMusica("Campeão", genero, compositor, "Você é campeão. Não deixe de lutar", Convert.ToDateTime("05/08/2013"));

            List<Musica> lstMusica = new List<Musica>();
            lstMusica.Add(musica);

            PlayListMusica playlists = new PlayListMusica();
            playlists.AdicionarPlayListMusica("Gospel favorita", true, usuario, lstMusica);

            usuario.LstPlayListMusica.Add(playlists);

            //Assert
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Nome);
            Assert.NotNull(usuario.Telefone);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.Telefone == telefone);
            Assert.True(usuario.Senha != senha);

            Assert.True(usuario.LstAssinatura.Count > 0);
            Assert.Same(usuario.LstAssinatura[0].Plano, plano);

            Assert.True(usuario.LstCartao.Count > 0);
            Assert.Same(usuario.LstCartao[0], cartao);

            Assert.True(usuario.LstPlayListMusica.Count > 0);
            Assert.Same(usuario.LstPlayListMusica[0], playlists);
        }
    }
}
