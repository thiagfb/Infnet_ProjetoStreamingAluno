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

        public String Backdrop { get; set; }

        public Artista AdicionarArtista(String nome, String Backdrop)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new Exception("Título do álbum é obrigatório.");
            }
            else
            {
                this.Id = Guid.NewGuid();

                this.Nome = nome;

                this.Backdrop = Backdrop;

                return this;
            }
        }
    }
}
