using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Streaming.Domain.Conta.Aggregates;
using Streaming.Domain.Notificacao;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Repository
{
    public class StreamingContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Artista> Artista { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Compositor> Compositor { get; set; }
        public DbSet<Faixa> Faixa { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<PlayListMusica> PlayListMusica { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Bandeira> Bandeira { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<MusicaPlayList> MusicaPlayList { get; set; }

        public StreamingContext(DbContextOptions<StreamingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StreamingContext).Assembly);
            modelBuilder.Entity<MusicaPlayList>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}