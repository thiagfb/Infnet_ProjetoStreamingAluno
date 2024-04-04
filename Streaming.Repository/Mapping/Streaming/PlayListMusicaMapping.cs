using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Mapping.Streaming
{
    public class PlayListMusicaMapping : IEntityTypeConfiguration<PlayListMusica>
    {
        public void Configure(EntityTypeBuilder<PlayListMusica> builder)
        {
            builder.ToTable(nameof(PlayListMusica));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Publica).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();

            builder.HasMany(x => x.LstMusica).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
