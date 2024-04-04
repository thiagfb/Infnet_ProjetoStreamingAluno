using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Streaming.Aggregates;

namespace Streaming.Repository.Mapping.Streaming
{
    internal class CompositorMapping : IEntityTypeConfiguration<Compositor>
    {
        public void Configure(EntityTypeBuilder<Compositor> builder)
        {
            builder.ToTable(nameof(Compositor));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}