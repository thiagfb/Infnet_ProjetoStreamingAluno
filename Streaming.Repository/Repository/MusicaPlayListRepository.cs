using Microsoft.EntityFrameworkCore;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Repository
{
    public class MusicaPlayListRepository : RepositoryBase<MusicaPlayList>
    {
        public StreamingContext Context { get; set; }

        public MusicaPlayListRepository(StreamingContext context) : base(context)
        {
            Context = context;
        }

        public void InsertMusic(MusicaPlayList musica)
        {
            string sql = "INSERT INTO MusicaPlayList (UsuarioId, MusicaId) VALUES({0}, {1})";
            Context.Database.ExecuteSqlRaw(sql, musica.UsuarioId, musica.MusicaId);
        }

        public void DeleteMusic(MusicaPlayList musica)
        {
            string sql = "DELETE FROM MusicaPlayList WHERE UsuarioId = {0} AND MusicaId = {1}";
            Context.Database.ExecuteSqlRaw(sql, musica.UsuarioId, musica.MusicaId);
        }
    }
}
