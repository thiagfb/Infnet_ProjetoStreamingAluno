using Streaming.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Tests.Domain.Streaming
{
    public class ArtistaTest
    {
        [Fact]
        public void ArtistaComSucesso() 
        {
            String nome = "Cassiane";

            Artista genero = new Artista()
            {
                Id  = Guid.NewGuid(),
                Nome = nome
            };            

            Assert.Equal(genero.Nome, nome);
        }
    }
}
