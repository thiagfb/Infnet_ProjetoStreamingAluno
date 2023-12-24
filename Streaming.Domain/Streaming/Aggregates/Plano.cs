using Streaming.Domain.Comum.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Plano
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public Monetario Valor { get; set; }

        //Em dias
        public int Periodo { get; set; }

        public Plano AdicionarPlano(String nome, String descricao, Monetario valor, int periodo)
        {
            this.Id = Guid.NewGuid();

            this.Nome = nome;

            this.Descricao = descricao;

            this.Valor = valor;

            this.Periodo = periodo;

            return this;
        }
    }
}
