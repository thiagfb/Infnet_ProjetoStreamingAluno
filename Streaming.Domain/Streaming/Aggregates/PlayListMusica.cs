using Streaming.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class PlayListMusica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Publica { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual List<Musica> LstMusica { get; set; } = new List<Musica>();

        public PlayListMusica AdicionarPlayListMusica(string nome, bool publica, Usuario usuario, List<Musica> lstMusica)
        {
            Id = Guid.NewGuid();

            Nome = nome;

            Publica = publica;

            var ativo = usuario.LstAssinatura.Any(x => x.Ativo == true);

            if (ativo == false)
            {
                throw new Exception("Usuário sem plano ativo.");
            }
            else
            {
                Usuario = usuario;
            }

            LstMusica = lstMusica;

            return this;
        }
    }
}
