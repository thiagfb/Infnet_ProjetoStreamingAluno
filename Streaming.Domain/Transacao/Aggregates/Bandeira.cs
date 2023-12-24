using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Transacao.Aggregates
{
    public class Bandeira
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }

        public Bandeira AdicionarBandeira(String nome)
        {
            this.Id = Guid.NewGuid();

            if (!String.IsNullOrEmpty(nome))
            {
                this.Nome = nome.ToUpper();
            }
            else
            {
                throw new Exception("Nome da bandeira é obrigatório.");
            }

            return this;
        }
    }

}
