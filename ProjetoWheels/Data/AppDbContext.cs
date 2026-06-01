using Microsoft.EntityFrameworkCore;
using ProjetoWheels.Models;

namespace ProjetoWheels.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Bicicleta> Bicicletas { get; set; }

    public DbSet<Locacao> Locacoes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly);
    }
}