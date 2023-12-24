using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Artista
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }

        public Artista AdicionarArtista(String nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new Exception("Título do álbum é obrigatório.");
            }
            else
            {
                this.Id = Guid.NewGuid();

                this.Nome = nome;

                return this;
            }
        }
    }
}
