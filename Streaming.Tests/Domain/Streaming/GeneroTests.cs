using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.ValueObject;
using Streaming.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Tests.Domain.Streaming
{
    public class GeneroTests
    {
        [Fact]
        public void GeneroComSucesso()
        {
            Genero genero = new Genero();

            genero.AdicionarGenero("Gospel");
        }

        [Fact]
        public void GeneroComErro()
        {
            Genero genero = new Genero();

            Assert.Throws<Exception>(
                () => genero.AdicionarGenero(null));
        }
    }
}
