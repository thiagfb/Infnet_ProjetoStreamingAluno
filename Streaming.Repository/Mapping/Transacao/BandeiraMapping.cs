using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Transacao.Aggregates;

namespace Streaming.Repository.Mapping.Transacao
{
    public class BandeiraMapping : IEntityTypeConfiguration<Bandeira>
    {
        public void Configure(EntityTypeBuilder<Bandeira> builder)
        {
            builder.ToTable(nameof(Bandeira));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(15);
        }
    }
}
