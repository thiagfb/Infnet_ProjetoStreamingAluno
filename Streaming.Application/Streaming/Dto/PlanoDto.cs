using Streaming.Domain.Comum.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Application.Streaming.Dto
{
    public class PlanoDto
    {
        public Guid Id { get; set; }

        public String Nome { get; set; }

        public String Descricao { get; set; }

        public Monetario Valor { get; set; }

        //Em dias
        public int Periodo { get; set; }
    }
}
