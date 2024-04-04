using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Streaming.ValueObject;

namespace Streaming.Repository.Mapping.Streaming
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable(nameof(Album));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Artista).WithMany();

            builder.Property(x => x.AnoLancamento).IsRequired().HasMaxLength(4);

            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(10);
            });

            builder.HasMany(x => x.LstFaixa).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
