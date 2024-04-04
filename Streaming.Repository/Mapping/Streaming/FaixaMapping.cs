using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Streaming.Aggregates;
using Streaming.Domain.Streaming.ValueObject;

namespace Streaming.Repository.Mapping.Streaming
{
    public class FaixaMapping : IEntityTypeConfiguration<Faixa>
    {
        public void Configure(EntityTypeBuilder<Faixa> builder)
        {
            builder.ToTable(nameof(Faixa));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Musica).WithMany();

            builder.Property(x => x.Ordem).IsRequired().HasMaxLength(3);

            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(10);
            });
        }
    }
}