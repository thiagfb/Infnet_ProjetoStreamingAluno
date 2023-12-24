
using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain;
using Streaming.Domain.Notificacao;

namespace Streaming.Tests.Domain
{
    public class NotificacaoTests
    {
        [Fact]
        public void NotificacaoTransacaoUsuarioComSucesso()
        {
            //Act
            string titulo = "teste notificação sucesso";
            string menssagem = "Mensagem sucesso";

            Usuario usuario = new Usuario();

            Usuario usuarioDestino = usuario.CriarUsuario("Usuario destino", "usuario.destino@teste.com", Convert.ToDateTime("12/08/1982"), "123456789", "abacaxi23");

            Usuario usuarioRemetente = usuario.CriarUsuario("Usuario origem", "usuario.destino@teste.com", Convert.ToDateTime("12/08/1982"), "123456789", "abacaxi23");

            Notificacao notificacao = new Notificacao();
            notificacao = notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, usuarioRemetente);
            usuarioDestino.LstNotificacao.Add(notificacao);

            Assert.True(usuarioDestino.LstNotificacao.Count > 0);
            Assert.Same(usuarioDestino.LstNotificacao[0].Titulo, titulo);
        }

        [Fact]
        public void NotificacaoInvalida()
        {

            string titulo = "teste notificação sucesso";
            string menssagem = "Mensagem sucesso";

            Usuario usuarioDestino = new Usuario();
            usuarioDestino = usuarioDestino.CriarUsuario("Usuario Destino", "usuario.destino@teste.com", Convert.ToDateTime("12/08/1982"), "123456789", "abacaxi23");

            Notificacao notificacao = new Notificacao();

            Assert.Throws<ArgumentNullException>(() =>
            {
                notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, null);
            });

        }
    }
}
