using LocadoraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAPI.Context
{
    public class LocadoraDBContext : DbContext
    {
        public LocadoraDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Locacao>? Locacoes { get; set; }

    }
}
