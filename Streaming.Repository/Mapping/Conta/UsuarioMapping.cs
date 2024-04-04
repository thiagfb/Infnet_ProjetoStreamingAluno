using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streaming.Domain.Conta.Aggregates;

namespace Streaming.Repository.Mapping.Conta
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();

            builder.HasMany(x => x.LstCartao).WithOne();
            builder.HasMany(x => x.LstAssinatura).WithOne();
            builder.HasMany(x => x.LstPlayListMusica).WithOne(x => x.Usuario);

        }
    }
}
