using Streaming.Domain.Conta.Aggregates;

namespace Streaming.Domain.Streaming.Aggregates
{
    public class MusicaPlayList
    {
        //public Guid Id { get; set; }

        //public virtual Usuario Usuario { get; set; }

        //public virtual Musica Musica { get; set; }
        public virtual Guid UsuarioId { get; set; }

        public virtual Guid MusicaId { get; set; }

        //public MusicaPlayList Adicionar(Usuario Usuario, Musica Musica)
        //{
        //    //this.Id = Guid.NewGuid();

        //    this.Usuario = Usuario;

        //    this.Musica = Musica;

        //    return this;
        //}
    }
}
