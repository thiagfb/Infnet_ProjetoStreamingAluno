using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Genero
    {
        public Guid Id { get; set; }

        public String Tipo { get; set; }

        public Genero AdicionarGenero(String tipo)
        {
            this.Id = Guid.NewGuid();

            if (!String.IsNullOrEmpty(tipo))
            {
                this.Tipo = tipo;
            }
            else
            {
                throw new Exception("Tipo de genêro musical é obrigatório.");
            }

            return this;
        }
    }
}
