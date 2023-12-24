using Streaming.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Notificacao
{
    public class Notificacao
    {
        public const string NOTIFICACAO_TRANSACAO_AUTORIZADA = "Transação realizada.";

        public Guid Id { get; set; }
        public DateTime DataNotificacao { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
        public Usuario UsuarioDestino { get; set; }
        public Usuario? UsuarioRemetente { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }


        public Notificacao Criar(string titulo, string mensagem, TipoNotificacao tipoNotificacao, Usuario destino, Usuario remetente = null)
        {
            if (tipoNotificacao == TipoNotificacao.Usuario && remetente == null)
            {
                throw new ArgumentNullException("Para tipo de mensagem 'usuário', você deve informar quem foi o remetente");
            }

            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentNullException("Informe o titulo da notificacao");
            }

            if (string.IsNullOrWhiteSpace(mensagem))
            {
                throw new ArgumentNullException("Informe o mensagem da notificacao");
            }

            return new Notificacao()
            {
                DataNotificacao = DateTime.Now,
                Mensagem = mensagem,
                TipoNotificacao = tipoNotificacao,
                Titulo = titulo,
                UsuarioDestino = destino,
                UsuarioRemetente = remetente
            };
        }
    }

    public enum TipoNotificacao
    {
        Usuario = 1,
        Sistema = 2
    }

}
