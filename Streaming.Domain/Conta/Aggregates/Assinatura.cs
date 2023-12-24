﻿using Streaming.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Domain.Conta.Aggregates
{
    public class Assinatura
    {
        public Guid Id { get; set; }
        public Plano Plano { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DataAtivacao { get; set; }

        public DateTime DataAtivacaoFim { get; set; }
    }
}
