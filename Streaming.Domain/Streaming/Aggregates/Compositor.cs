using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Compositor
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }

        public Compositor AdicionarCompositor(String nome)
        {
            this.Id = Guid.NewGuid();

            if (!String.IsNullOrEmpty(nome))
            {
                this.Nome = nome;
            }
            else
            {
                throw new Exception("Nome do compositor é obrigatório.");
            }

            return this;
        }
    }
}
