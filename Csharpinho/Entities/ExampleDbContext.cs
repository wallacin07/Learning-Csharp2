using Microsoft.EntityFrameworkCore;

namespace Exemplo.Entities;

public class ExampleDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EntityA> EntityAs { get; set; }
    public DbSet<EntityB> EntityBs { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    override protected void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<EntityA>()
        .HasMany(e => e.EntityBs)
        .WithMany(e => e.EntityAs);

        builder.Entity<Usuario>()
        .HasMany(e => e.Seguidores)
        .WithOne(e=> e.Seguido)
        .HasForeignKey(e=>e.SeguidoId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Usuario>()
        .HasMany(e => e.Seguindo)
        .WithOne(e=> e.Seguidor)
        .HasForeignKey(e=>e.SeguidoId)
        .OnDelete(DeleteBehavior.Cascade);
        
    }

}