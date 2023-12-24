using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.Aggregates;
using Streaming.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Tests.Domain.Streaming
{
    public class MusicaTests
    {
        [Fact]
        public void MusicaComSucesso()
        {
            Genero genero = new Genero();
            genero.AdicionarGenero("Gospel");

            Compositor compositor = new Compositor();
            compositor = compositor.AdicionarCompositor("Anderson Freire");

            Musica musica = new Musica();
            String titulo = "Campeão";

            musica.AdicionarMusica(titulo, genero, compositor, "Você é campeão. Não desista", Convert.ToDateTime("01/04/2013"));

            Assert.Equal(musica.Titulo, titulo);
        }
    }
}
