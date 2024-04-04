using Streaming.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Faixa
    {
        public Guid Id { get; set; }

        public virtual Musica Musica { get; set; }

        public int Ordem { get; set; }

        public virtual Duracao Duracao { get; set; }

        public Faixa AdicionarFaixa(Musica musica, int ordem, Duracao duracao)
        {
            this.Musica = musica;

            this.Ordem = ordem;

            this.Duracao = duracao;

            return this;
        }
    }
}
