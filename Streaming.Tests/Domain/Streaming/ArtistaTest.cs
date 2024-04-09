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

            Artista artista = new Artista();
            artista = artista.AdicionarArtista(nome, "c:\\imagem.jpg");

            Assert.Equal(artista.Nome, nome);
        }
    }
}
