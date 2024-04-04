using Streaming.Domain.Streaming.ValueObject;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }

        public String Titulo { get; set; }

        public virtual Artista Artista { get; set; }

        public int AnoLancamento { get; set; }

        public Duracao? Duracao { get; set; }

        public virtual List<Faixa> LstFaixa { get; set; } = new List<Faixa>();

        public Album AdicionarAlbum(String titulo, Artista artista, int anoLancamento, Duracao? duracao, List<Faixa> lstFaixa)
        {
            this.Id = Guid.NewGuid();

            if (String.IsNullOrEmpty(titulo))
            {
                throw new Exception("Título do álbum é obrigatório.");
            }
            else
            {
                this.Titulo = titulo;
            }

            this.Artista = artista;

            if (anoLancamento <= 0)
            {
                throw new Exception("Ano de lançamento do álbum é obrigatório.");
            }
            else
            {
                this.AnoLancamento = anoLancamento;
            }

            this.Duracao = duracao;

            if (lstFaixa != null && lstFaixa.Count > 0)
            {
                this.LstFaixa.AddRange(lstFaixa);
            }
            else
            {
                throw new Exception("É necessário ter faixa músical.");
            }

            return this;
        }
    }
}
