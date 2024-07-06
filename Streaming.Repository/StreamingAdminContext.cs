using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Streaming.Domain.Admin.Aggregates;
using Streaming.Repository.Mapping.Admin;

namespace Streaming.Repository
{
    public class StreamingAdminContext : DbContext
    {
        public DbSet<UsuarioAdmin> UsuarioAdmins { get; set; }

        public StreamingAdminContext(DbContextOptions<StreamingAdminContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioAdminMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
