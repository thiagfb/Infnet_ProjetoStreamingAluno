using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Tests.Domain.Notificacao
{
    public class NotificacaoTests
    {
        [Fact]
        public void NotificacaoTransacaoUsuarioComSucesso()
        {

            //Act
            string titulo = "Titulo teste notificação sucesso";
            string menssagem = "Mensagem sucesso";

            Usuario usuario = new Usuario();
            Usuario usuarioRemetente = usuario.CriarUsuario("Usuario Destino", "usuario.destino@teste.com", Convert.ToDateTime("12/08/1982"), "123456789", "abacaxi23");

            Notificacao notificacao = new Domain.Notificacao();

            var notificacao = SpotifyMs.Domain.Notificacao.Notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, usuarioRemetente);
            usuarioDestino.Notificacoes.Add(notificacao);

            Assert.True(usuarioDestino.Notificacoes.Count > 0);
            Assert.Same(usuarioDestino.Notificacoes[0].Titulo, titulo);
        }

        [Fact]
        public void NotificacaoInvalida()
        {

            //Act
            string titulo = "Titulo teste notificação sucesso";
            string menssagem = "Mensagem sucesso";

            Usuario usuarioDestino = Usuario.Criar("Usuario Destino", "usuario.destino@teste.com", "123456", DateTime.Now.AddYears(-18));

            Assert.Throws<ArgumentNullException>(() =>
            {
                SpotifyMs.Domain.Notificacao.Notificacao.Criar(titulo, menssagem, TipoNotificacao.Usuario, usuarioDestino, null);
            });

        }
    }
}
