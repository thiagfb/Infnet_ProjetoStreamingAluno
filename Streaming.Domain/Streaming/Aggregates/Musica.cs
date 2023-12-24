using Streaming.Domain.Comum.ValueObject;
using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }

        public String Titulo { get; set; }

        public Genero Genero { get; set; }

        public Compositor Compositor { get; set; }

        public String Letra { get; set; }

        public DateTime DataComposicao { get; set; }

        public Musica AdicionarMusica(String titulo, Genero genero, Compositor compositor, String letra, DateTime DataComposicao)
        {
            this.Id = Guid.NewGuid();

            if (String.IsNullOrEmpty(titulo))
            {
                throw new Exception("Título é obrigatório.");
            }
            else
            {
                this.Titulo = titulo;
            }

            this.Genero = genero;

            this.Compositor = compositor;

            this.Letra = letra;

            this.DataComposicao = DataComposicao;

            return this;
        }
    }
}
