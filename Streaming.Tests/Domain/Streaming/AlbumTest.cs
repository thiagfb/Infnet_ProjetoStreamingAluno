using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Tests.Domain.Streaming
{
    public class AlbumTest
    {
        [Fact]
        public void CriarAlbumComSucesso()
        {
            Genero genero = new Genero();
            genero.AdicionarGenero("Gospel");

            Compositor compositor = new Compositor();
            compositor = compositor.AdicionarCompositor("Anderson Freire");

            Musica musica = new Musica();

            List<Musica> lstMusica = new List<Musica>();
            String titulo = "Campeão";

            musica = musica.AdicionarMusica(titulo, genero, compositor, "Você é campeão. Não desista", Convert.ToDateTime("01/04/2013"));
            lstMusica.Add(musica);

            Faixa faixa = new Faixa();
            List<Faixa> lstFaixa = new List<Faixa>();
            lstFaixa.Add(faixa.AdicionarFaixa(musica, 1, 12));

            Artista artista = new Artista();
            artista = artista.AdicionarArtista("Cassiane", "c:\\imagem.jpg");

            Album album = new Album();
            album = album.AdicionarAlbum("Inesquesível", artista, 2023, 13, lstFaixa);

            Assert.True(album.LstFaixa.Count > 0);
            Assert.Same(album.LstFaixa[0], faixa);
        }
    }
}
