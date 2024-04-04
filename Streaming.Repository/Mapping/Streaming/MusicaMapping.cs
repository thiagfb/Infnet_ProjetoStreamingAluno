using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Mapping.Streaming
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable(nameof(Musica));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Genero).WithMany();
            builder.HasOne(x => x.Compositor).WithMany();

            builder.Property(x => x.Letra).IsRequired();

            builder.Property(x => x.DataComposicao).IsRequired();
        }
    }
}
